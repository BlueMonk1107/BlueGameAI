
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

        public override IState GetEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.MOVE, true);
            return effects;
        }

        public override bool IsGoalComplete()
        {
            return GetAgentStateValue(KeyNameEnum.MOVE) == true;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentStateValue(KeyNameEnum.ATTACK_IDLE) == true;
        }
    }
}
