
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
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.Set(KeyNameEnum.INJURE, true);
            return effects;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.Set(KeyNameEnum.INJURE, false);
            return effects;
        }


    }
}
