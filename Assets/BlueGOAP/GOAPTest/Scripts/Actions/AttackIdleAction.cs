
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AttackIdleAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.ATTACK_IDLE; } }
        public override int Cost { get { return 1; } }
        public override int Priority { get { return 0; } }
        public override bool CanInterruptiblePlan { get { return false; } }

        public AttackIdleAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.ATTACK_IDLE, true);
            return effects;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.MOVE, true);
            return effects;
        }
    }
}
