
using BlueGOAP;

namespace BlueGOAPTest
{
    public class IdleGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public override GoalEnum Label
        {
            get { return GoalEnum.IDLE; }
        }

        public IdleGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override IState GetEffects()
        {
            return null;
        }

        public override bool IsGoalComplete()
        {
            return GetAgentStateValue(KeyNameEnum.FIND_ENEMY) == true;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentStateValue(KeyNameEnum.FIND_ENEMY) == false;
        }
    }
}
