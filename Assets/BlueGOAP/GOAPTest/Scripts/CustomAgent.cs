
using System;
using BlueGOAP;

namespace BlueGOAPTest
{
    public class CustomAgent : AgentBase<ActionEnum, GoalEnum>
    {
        public CustomAgent(): base() { }

        protected override IState InitAgentState()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();

            foreach (KeyNameEnum keyNameEnum in Enum.GetValues(typeof(KeyNameEnum)))
            {
                effects.Set(keyNameEnum, false);
            }

            effects.Set(KeyNameEnum.IDLE,true);

            return effects;
        }

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
