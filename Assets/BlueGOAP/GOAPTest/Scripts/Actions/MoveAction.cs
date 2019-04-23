
using BlueGOAP;

namespace BlueGOAPTest
{
    public class MoveAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.MOVE; } }
        public override int Cost { get { return 5; } }
        public override int Priority { get { return 70; } }
        public override bool CanInterruptiblePlan { get { return false; } }

        public MoveAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.CAN_MOVE, true);
            return state;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.NEAR_ENEMY, true);
            state.Set(KeyNameEnum.CAN_MOVE, false);
            return state;
        }
    }
}
