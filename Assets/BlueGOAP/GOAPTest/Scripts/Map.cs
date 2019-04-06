
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
            AddAction(new IdleHandler(new IdleAction(_agent)));
            AddAction(new AttackHandler(new AttackAction(_agent)));
            AddAction(new InjureHandler(new InjureAction(_agent)));
            AddAction(new MoveHandler(new MoveAction(_agent)));
        }

        protected override void InitGoalMaps()
        {
            AddGoal(new AttackGoal(_agent));
            AddGoal(new IdleGoal(_agent));
        }
    }
}
