
using BlueGOAP;

namespace BlueGOAPTest
{
    public class CustomAgent : Agent<ActionEnum, GoalEnum>
    {
        public CustomAgent(): base() { }
        
        protected override IMaps<ActionEnum, GoalEnum> InitMaps()
        {
            return new Map(this);
        }

        protected override IActionManager<ActionEnum> InitActionManager()
        {
            return new CustomActionMgr(this);
        }

        protected override IGoalManager<GoalEnum> InitGoalManager()
        {
            return new CustomGoalMgr(this);
        }

        protected override ITriggerManager InitTriggerManager()
        {
            return new CustomTriggerMgr(this);
        }

        protected override DebugMsgBase InitDebugMsg()
        {
            return new CustomDebug();
        }
    }
}
