
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
