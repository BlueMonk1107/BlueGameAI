
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AlertGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public override GoalEnum Label
        {
            get { return GoalEnum.ALERT; }
        }

        public AlertGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override float GetPriority()
        {
            return 1;
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
            state.Set(KeyNameEnum.FIND_ENEMY, true);
            state.Set(KeyNameEnum.CAN_MOVE, false);
            return state;
        }
    }
}
