
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
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.NEAR_ENEMY, true);
            return state;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.ATTACK_IDLE, true);
            return state;
        }
    }
}
