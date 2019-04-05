
using BlueGOAP;

namespace BlueGOAPTest
{
    public class CustomGoalMgr : GoalManagerBase<ActionEnum, GoalEnum>
    {
        public CustomGoalMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override void InitGoals()
        {
            throw new System.NotImplementedException();
        }
    }
}
