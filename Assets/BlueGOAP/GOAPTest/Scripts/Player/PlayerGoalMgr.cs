
using BlueGOAP;

namespace BlueGOAPTest
{
    public class PlayerGoalMgr : GoalManagerBase<ActionEnum, GoalEnum>
    {
        public PlayerGoalMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override void InitGoals()
        {
        }
    }
}
