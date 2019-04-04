
namespace BlueGOAP
{
    public class Performer<TAction, TGoal> : IPerformer
    {
        private IPlanHandler<TAction> _planHandler;
        private IPlanner<TAction> _planner;
        private IGoalManager<TGoal> _goalManager;
        private IActionManager<TAction> _actionManager;

        public Performer(IAgent<TAction, TGoal> agent)
        {
            _planHandler = new PlanHandler<TAction>();
            _planHandler.AddCompleteCallBack(PlanComplete);
            _planner = new Planner<TAction, TGoal>(agent);
            _goalManager = agent.GoalManager;
            _actionManager = agent.ActionManager;
        }

        public void UpdateData()
        {
            if (WhetherToReplan())
            {
                BuildPlanAndStart();
            }
        }

        //制定计划并开始计划
        private void BuildPlanAndStart()
        {
            //若目标完成则重新寻找目标
            var plan = _planner.BuildPlan(_goalManager.CurrentGoal);
            if (plan != null && plan.Count > 0)
            {
                _planHandler.Init(_actionManager, plan);
                _planHandler.StartPlan();
                _actionManager.IsPerformAction = true;
            }
        }

        //计划完成
        private void PlanComplete()
        {
            _actionManager.IsPerformAction = false;
            BuildPlanAndStart();
        }

        //检测是否需要重新制定计划
        private bool WhetherToReplan()
        {
            //当前计划是否正在执行
            if (_planHandler.InProgress)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
