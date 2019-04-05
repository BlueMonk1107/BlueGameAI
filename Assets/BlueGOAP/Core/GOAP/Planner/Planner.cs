using System.Collections;
using System.Collections.Generic;

namespace BlueGOAP
{
    /// <summary>
    /// 优先级比较器
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    class PrecedenceComparer<TAction> : IComparer<IActionHandler<TAction>>
    {
        public int Compare(IActionHandler<TAction> x, IActionHandler<TAction> y)
        {
            return x.Action.Precedence - y.Action.Precedence;
        }
    }
    public class Planner<TAction, TGoal> : IPlanner<TAction, TGoal>
    {
        private IAgent<TAction, TGoal> _agent;
        private Tree<TAction> _tree;
        private Queue<IActionHandler<TAction>> _plan;

        public Planner(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
            _plan = new Queue<IActionHandler<TAction>>();
        }

        public IAction<TAction> GetCurrentAction()
        {
            return null;
        }

        public Queue<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal)
        {
            _plan.Clear();

            if (goal == null)
                return _plan;

            TreeNode<TAction> currentNode = Plan(goal);
            while (currentNode.ID != -1)
            {
                _plan.Enqueue(currentNode.ActionHandler);
                currentNode = currentNode.ParentNode;
            }
            return _plan;
        }

        public TreeNode<TAction> Plan(IGoal<TGoal> goal)
        {
            //初始化树的顶点
            TreeNode<TAction> topNode = _tree.CreateTopNode();
            SetNodeState(topNode, goal, null);
            topNode.Cost = GetCost(topNode);

            TreeNode<TAction> cheapestNode = topNode;
            TreeNode<TAction> currentNode = cheapestNode;
            while (!IsEnd(currentNode))
            {
                currentNode = cheapestNode;
                cheapestNode = null;
                //获取所有的子行为
                List<IActionHandler<TAction>> handlers = GetSubHandlers(currentNode);
                TreeNode<TAction> subNode = null;
                for (int i = 0; i < handlers.Count; i++)
                {
                    subNode = _tree.CreateNode(handlers[i]);
                    subNode.Cost = GetCost(subNode);
                    subNode.ParentNode = currentNode;
                    cheapestNode = GetCheapestNode(subNode, cheapestNode);
                }
            }

            return currentNode;
        }

        private TreeNode<TAction> GetCheapestNode(TreeNode<TAction> nodeA, TreeNode<TAction> nodeB)
        {
            if (nodeA == null || nodeA.ActionHandler == null)
                return nodeB;

            if (nodeB == null || nodeB.ActionHandler == null)
                return nodeA;

            if (nodeA.Cost > nodeB.Cost)
            {
                return nodeB;
            }
            else if (nodeA.Cost < nodeB.Cost)
            {
                return nodeA;
            }
            else
            {
                if (nodeA.ActionHandler.Action.Precedence > nodeB.ActionHandler.Action.Precedence)
                {
                    return nodeA;
                }
                else
                {
                    return nodeB;
                }
            }
        }

        private bool IsEnd(TreeNode<TAction> currentNode)
        {
            if (currentNode == null)
                return true;

            if (GetStateDifferecnceNum(currentNode) == 0)
                return true;

            return false;
        }

        private void SetNodeState(TreeNode<TAction> node, IGoal<TGoal> goal, IActionHandler<TAction> handler)
        {
            IState goalEffects = goal.GetEffects();
            //第一个节点的id为-1
            if (node.ID == -1)
            {
                node.GoalState = goalEffects;
            }
            else
            {
                IState data = goalEffects.GetSameData(handler.Action.Effects);
                //查找action的effects，若同时在goal中也存在，那么就把这个状态添加到节点的当前状态中
                node.CurrentState.SetData(data);
                //把action的先决条件设置到节点的goalState中
                node.GoalState.SetData(handler.Action.Preconditions);
                //把GoalState中有且CurrentState没有的添加到CurrentState中
                //数据从agent的当前状态中获取
                node.CurrentState.SetKeys(_agent.AgentState, node.GoalState);
            }
        }

        private int GetCost(TreeNode<TAction> node)
        {
            int actionCost = 0;
            if (node.ActionHandler != null)
                actionCost = node.ActionHandler.Action.Cost;

            return node.Cost + GetStateDifferecnceNum(node) + actionCost;
        }

        private int GetStateDifferecnceNum(TreeNode<TAction> node)
        {
            return node.CurrentState.GetValueDifferences(node.GoalState).Count;
        }

        /// <summary>
        /// 获取所有的子节点行为
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<IActionHandler<TAction>> GetSubHandlers(TreeNode<TAction> node)
        {
            List<IActionHandler<TAction>> handlers = new List<IActionHandler<TAction>>();

            //获取状态差异
            var keys = node.CurrentState.GetValueDifferences(node.GoalState);
            var map = _agent.ActionManager.EffectsAndActionMap;

            foreach (object key in keys)
            {
                if (map.ContainsKey(key))
                {
                    foreach (IActionHandler<TAction> handler in map[key])
                    {
                        //筛选能够执行的动作
                        if (handler.CanPerformAction())
                        {
                            handlers.Add(handler);
                        }
                    }
                }
            }
            //进行优先级排序
            handlers.Sort(new PrecedenceComparer<TAction>());
            return handlers;
        }

        //先根据差异的键值获取对应的acton
        //然后检测action的执行条件是否满足
        //满足就找到花费最小的加入当前队列
        //

        public bool IsFinish()
        {
            throw new System.NotImplementedException();
        }

        public void Interruptible()
        {
            throw new System.NotImplementedException();
        }
    }
}
