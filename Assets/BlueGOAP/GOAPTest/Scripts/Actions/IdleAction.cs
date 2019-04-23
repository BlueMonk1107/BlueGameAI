
using BlueGOAP;

namespace BlueGOAPTest
{
    public class IdleAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.IDLE; } }
        public override int Cost { get { return 1; } }
        public override int Priority { get { return 0; } }
        public override bool CanInterruptiblePlan { get { return false; } }

        public IdleAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.FIND_ENEMY, false);
            state.Set(KeyNameEnum.CAN_ATTACK, false);
            state.Set(KeyNameEnum.CAN_MOVE, false);
            return state;
        }

        protected override IState InitEffects()
        {
            return null;
        }
    }
}
