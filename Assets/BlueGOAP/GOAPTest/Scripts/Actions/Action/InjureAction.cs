
using BlueGOAP;

namespace BlueGOAPTest
{
    public class InjureAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE; } }
        public override int Cost { get { return 1; } }
        public override int Priority { get { return 100; } }
        public override bool CanInterruptiblePlan { get { return true; } }

        public InjureAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.INJURE, true);
            return state;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.INJURE, false);
            return state;
        }


    }
}
