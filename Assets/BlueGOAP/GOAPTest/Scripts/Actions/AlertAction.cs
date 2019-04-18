
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AlertAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.ALERT; } }
        public override int Cost { get { return 1; } }
        public override int Priority { get { return 0; } }

        public override bool CanInterruptiblePlan { get { return false; } }

        public AlertAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.Set(KeyNameEnum.FIND_ENEMY, false);
            return effects;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.Set(KeyNameEnum.MOVE, true);
            return effects;
        }
    }
}
