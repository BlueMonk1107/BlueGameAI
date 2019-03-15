
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
            return 4;
        }

        public override IState GetEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.ATTACK_IDLE, true);
            return effects;
        }

        public override bool IsGoalComplete()
        {
            return GetAgentStateValue(KeyNameEnum.ATTACK_IDLE) == true;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentStateValue(KeyNameEnum.FIND_ENEMY) == true
                && GetAgentStateValue(KeyNameEnum.ATTACK_IDLE) == false;
        }
    }
}
