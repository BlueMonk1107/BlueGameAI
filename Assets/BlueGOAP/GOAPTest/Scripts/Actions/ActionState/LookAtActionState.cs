
using BlueGOAP;

namespace BlueGOAPTest
{
    public class LookAtActionState: ActionBase<ActionEnum,GoalEnum>
    {

        public override ActionEnum Label { get {return ActionEnum.LOOK_AT;} }
        public override int Cost { get; }
        public override int Priority { get; }
        public override bool CanInterruptiblePlan { get; }

        public LookAtActionState(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.FIND_ENEMY,true);
            return state;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.FIND_ENEMY, false);
            return state;
        }
    }
}
