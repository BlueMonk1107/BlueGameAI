
using System;
using BlueGOAP;

namespace BlueGOAPTest
{
    public class CustomAgent : AgentBase<ActionEnum, GoalEnum>
    {
        public CustomAgent(): base(null) { }

        protected override IState InitAgentState()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();

            foreach (KeyNameEnum keyNameEnum in Enum.GetValues(typeof(KeyNameEnum)))
            {
                state.Set(keyNameEnum, false);
            }

            state.Set(KeyNameEnum.IDLE,true);

            return state;
        }

        protected override IMaps<ActionEnum, GoalEnum> InitMaps()
        {
            return new Map(this,null);
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
