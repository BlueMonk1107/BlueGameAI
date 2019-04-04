
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

        //�ƶ��ƻ�����ʼ�ƻ�
        private void BuildPlanAndStart()
        {
            //��Ŀ�����������Ѱ��Ŀ��
            var plan = _planner.BuildPlan(_goalManager.CurrentGoal);
            if (plan != null && plan.Count > 0)
            {
                _planHandler.Init(_actionManager, plan);
                _planHandler.StartPlan();
                _actionManager.IsPerformAction = true;
            }
        }

        //�ƻ����
        private void PlanComplete()
        {
            _actionManager.IsPerformAction = false;
            BuildPlanAndStart();
        }

        //����Ƿ���Ҫ�����ƶ��ƻ�
        private bool WhetherToReplan()
        {
            //��ǰ�ƻ��Ƿ�����ִ��
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
