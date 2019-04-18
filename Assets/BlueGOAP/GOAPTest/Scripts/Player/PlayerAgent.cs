
using System;
using BlueGOAP;

namespace BlueGOAPTest
{
    public class PlayerAgent : AgentBase<ActionEnum, GoalEnum>
    {
        public PlayerAgent() : base() { }

        protected override DebugMsgBase InitDebugMsg()
        {
            return new CustomDebug();
        }

        protected override IState InitAgentState()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();

            foreach (KeyNameEnum key in Enum.GetValues(typeof(KeyNameEnum)))
            {
                state.Set(key, false);
            }

            state.Set(KeyNameEnum.IDLE, true);

            return state;
        }

        protected override IMaps<ActionEnum, GoalEnum> InitMaps()
        {
            return new PlayerMap(this);
        }

        protected override IActionManager<ActionEnum> InitActionManager()
        {
            return new PlayerActMgr(this);
        }

        protected override IGoalManager<GoalEnum> InitGoalManager()
        {
            return new PlayerGoalMgr(this);
        }

        protected override ITriggerManager InitTriggerManager()
        {
            return new CustomTriggerMgr(this);
        }
    }
}
