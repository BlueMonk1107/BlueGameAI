
using BlueGOAP;

namespace BlueGOAPTest
{
    public class Map : MapsBase<ActionEnum, GoalEnum>
    {
        public Map(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override void InitActinMaps()
        {
            AddAction(new AlertHandler(_agent,new AlertAction(_agent)));
            AddAction(new AttackHandler(_agent, new AttackAction(_agent)));
            AddAction(new InjureHandler(_agent, new InjureAction(_agent)));
            AddAction(new MoveHandler(_agent, new MoveAction(_agent)));
        }

        protected override void InitGoalMaps()
        {
            AddGoal(new AttackGoal(_agent));
            AddGoal(new AlertGoal(_agent));
            AddGoal(new MoveGoal(_agent));
        }
    }
}
