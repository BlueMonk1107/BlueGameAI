
using System;
using BlueGOAP;

namespace BlueGOAPTest
{
    public class PlayerAgent : AgentBase<ActionEnum, GoalEnum>
    {
        public PlayerAgent() : base(null) { }

        protected override DebugMsgBase InitDebugMsg()
        {
            return new CustomDebug();
        }

        public override bool IsAgentOver { get { return false; } }

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
            return new PlayerMap(this,null);
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
