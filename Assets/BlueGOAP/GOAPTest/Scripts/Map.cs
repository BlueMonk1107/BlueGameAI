
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
            AddAction(new IdleHandler(_agent,new IdleAction(_agent)));
            AddAction(new AttackIdleHandler(_agent,new AttackIdleAction(_agent)));
            AddAction(new AlertHandler(_agent,new AlertAction(_agent)));
            AddAction(new AttackHandler(_agent, new AttackAction(_agent)));
            AddAction(new InjureHandler(_agent, new InjureAction(_agent)));
            AddAction(new MoveHandler(_agent, new MoveAction(_agent)));
        }

        protected override void InitGoalMaps()
        {
            AddGoal(new AttackGoal(_agent));
            AddGoal(new AlertGoal(_agent));
            AddGoal(new AttackIdleGoal(_agent));
            AddGoal(new InjureGoal(_agent));
        }

        protected override void InitGameData()
        {
            SetGameData(DataName.SELF_TRANS, ObjectsInScene.Instance.Enemy);
            SetGameData(DataName.ENEMY_TRANS, ObjectsInScene.Instance.Player);
        }
    }
}
