
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

        public override IState GetEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.LOOK_AT_ENEMY, true);
            return effects;
        }

        public override bool IsGoalComplete()
        {
            return GetAgentStateValue(KeyNameEnum.LOOK_AT_ENEMY) == true;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentStateValue(KeyNameEnum.FIND_ENEMY) == true
                && GetAgentStateValue(KeyNameEnum.LOOK_AT_ENEMY) == false;
        }
    }
}
