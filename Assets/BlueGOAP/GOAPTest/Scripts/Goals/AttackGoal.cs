
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AttackGoal : GoalBase<ActionEnum,GoalEnum>
    {
        public override GoalEnum Label
        {
            get { return GoalEnum.ATTACK; }
        }

        public AttackGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override float GetPriority()
        {
            return 3;
        }

        public override IState GetEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.ATTACK,false);
            return effects;
        }

        public override bool IsGoalComplete()
        {
            return GetAgentStateValue(KeyNameEnum.ATTACK) == false 
                && GetAgentStateValue(KeyNameEnum.LOOK_AT_ENEMY) == false;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentStateValue(KeyNameEnum.ATTACK) == true
                && GetAgentStateValue(KeyNameEnum.NEAR_ENEMY) == true;
        }
    }
}
