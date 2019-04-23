
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AttackIdleGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public AttackIdleGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override GoalEnum Label
        {
            get { return GoalEnum.ATTACK_IDLE; }
        }

        public override float GetPriority()
        {
            return 2;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.CAN_MOVE, true);
            return state;
        }

        protected override IState InitActiveCondition()
        {
            State<KeyNameEnum> state = new State<KeyNameEnum>();
            state.Set(KeyNameEnum.ATTACK_IDLE, true);
            return state;
        }
    }
}
