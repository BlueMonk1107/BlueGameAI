
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AttackAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.ATTACK; } }
        public override int Cost { get { return 1; } }
        public override int Priority { get { return 80; } }
        public override bool CanInterruptiblePlan { get { return false; } }

        public AttackAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.Set(KeyNameEnum.NEAR_ENEMY, true);
            return effects;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.Set(KeyNameEnum.ATTACK_IDLE, true);
            return effects;
        }
    }
}
