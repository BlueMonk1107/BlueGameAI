
using BlueGOAP;

namespace BlueGOAPTest
{
    public class CustomAgent : Agent<ActionEnum, GoalEnum>
    {
        public CustomAgent(): base() { }
        
        protected override IMaps<ActionEnum, GoalEnum> InitMaps()
        {
            return new Map();
        }

        protected override IActionManager<ActionEnum> InitActionManager()
        {
            return new CustomActionMgr(this);
        }

        protected override IGoalManager<GoalEnum> InitGoalManager()
        {
            return new CustomGoalMgr(this);
        }
    }
}
