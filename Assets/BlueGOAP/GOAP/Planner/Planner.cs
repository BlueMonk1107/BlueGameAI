using System.Collections;
using System.Collections.Generic;

namespace BlueGOAP
{
    /// <summary>
    /// ���ȼ��Ƚ���
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
            //��ʼ�����Ķ���
            TreeNode<TAction> topNode = _tree.CreateTopNode();
            SetNodeState(topNode, goal, null);
            topNode.Cost = GetCost(topNode);

            TreeNode<TAction> cheapestNode = topNode;
            TreeNode<TAction> currentNode = cheapestNode;
            while (!IsEnd(currentNode))
            {
                currentNode = cheapestNode;
                cheapestNode = null;
                //��ȡ���е�����Ϊ
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
            //��һ���ڵ��idΪ-1
            if (node.ID == -1)
            {
                node.GoalState = goalEffects;
            }
            else
            {
                IState data = goalEffects.GetSameData(handler.Action.Effects);
                //����action��effects����ͬʱ��goal��Ҳ���ڣ���ô�Ͱ����״̬��ӵ��ڵ�ĵ�ǰ״̬��
                node.CurrentState.SetData(data);
                //��action���Ⱦ��������õ��ڵ��goalState��
                node.GoalState.SetData(handler.Action.Preconditions);
                //��GoalState������CurrentStateû�е���ӵ�CurrentState��
                //���ݴ�agent�ĵ�ǰ״̬�л�ȡ
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
        /// ��ȡ���е��ӽڵ���Ϊ
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<IActionHandler<TAction>> GetSubHandlers(TreeNode<TAction> node)
        {
            List<IActionHandler<TAction>> handlers = new List<IActionHandler<TAction>>();

            //��ȡ״̬����
            var keys = node.CurrentState.GetValueDifferences(node.GoalState);
            var map = _agent.ActionManager.EffectsAndActionMap;

            foreach (object key in keys)
            {
                if (map.ContainsKey(key))
                {
                    foreach (IActionHandler<TAction> handler in map[key])
                    {
                        //ɸѡ�ܹ�ִ�еĶ���
                        if (handler.CanPerformAction())
                        {
                            handlers.Add(handler);
                        }
                    }
                }
            }
            //�������ȼ�����
            handlers.Sort(new PrecedenceComparer<TAction>());
            return handlers;
        }

        //�ȸ��ݲ���ļ�ֵ��ȡ��Ӧ��acton
        //Ȼ����action��ִ�������Ƿ�����
        //������ҵ�������С�ļ��뵱ǰ����
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
