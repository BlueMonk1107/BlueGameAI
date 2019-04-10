
using BlueGOAP;

namespace BlueGOAPTest
{
    public class MoveGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public override GoalEnum Label
        {
            get { return GoalEnum.MOVE; }
        }

        public MoveGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override float GetPriority()
        {
            return 3;
        }

        public override IState GetEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.NEAR_ENEMY, true);;
            return effects;
        }

        public override bool IsGoalComplete()
        {
            return GetAgentStateValue(KeyNameEnum.NEAR_ENEMY) == true;
        }

        protected override bool ActiveCondition()
        {
            return  GetAgentStateValue(KeyNameEnum.MOVE) == true;
        }
    }
}
