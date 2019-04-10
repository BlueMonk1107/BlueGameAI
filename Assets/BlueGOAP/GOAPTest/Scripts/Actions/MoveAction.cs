
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
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.MOVE, true);
            return effects;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.NEAR_ENEMY, true);
            return effects;
        }
    }
}
