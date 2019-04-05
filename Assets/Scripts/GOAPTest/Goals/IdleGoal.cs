
using BlueGOAP;

namespace BlueGOAPTest
{
    public class IdleGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public IdleGoal(IAgent<ActionEnum, GoalEnum> agent, GoalEnum label) : base(agent, label)
        {
        }

        public override IState GetEffects()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsGoalAchieved(IState state)
        {
            throw new System.NotImplementedException();
        }

        protected override bool IsSatisfyActiveCondition()
        {
            throw new System.NotImplementedException();
        }
    }
}
