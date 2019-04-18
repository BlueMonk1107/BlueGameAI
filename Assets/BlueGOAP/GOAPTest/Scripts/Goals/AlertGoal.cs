
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
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.Set(KeyNameEnum.MOVE, true);
            return effects;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentState(KeyNameEnum.FIND_ENEMY) == true
                && GetAgentState(KeyNameEnum.MOVE) == false;
        }
    }
}
