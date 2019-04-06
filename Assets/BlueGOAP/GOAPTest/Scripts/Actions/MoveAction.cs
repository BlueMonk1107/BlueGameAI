
using BlueGOAP;

namespace BlueGOAPTest
{
    public class MoveAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.MOVE; } }
        public override int Cost { get { return 1; } }
        public override int Precedence { get { return 0; } }

        public MoveAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.NEAR_ENEMY, false);
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
