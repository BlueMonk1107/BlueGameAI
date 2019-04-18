
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
            AddAction<IdleHandler, IdleAction>();
            AddAction<AttackIdleHandler, AttackIdleAction>();
            AddAction<AlertHandler, AlertAction>();
            AddAction<AttackHandler, AttackAction>();
            AddAction<InjureHandler, InjureAction>();
            AddAction<MoveHandler, MoveAction>();
            AddAction<LookAtHandler, LookAtAction>();
        }

        protected override void InitGoalMaps()
        {
            AddGoal<AlertGoal>();
            AddGoal<AttackGoal>();
            AddGoal<AttackIdleGoal>();
            AddGoal<InjureGoal>();
        }

        protected override void InitGameData()
        {
            SetGameData(DataName.SELF_TRANS, ObjectsInScene.Instance.Enemy);
            SetGameData(DataName.ENEMY_TRANS, ObjectsInScene.Instance.Player);
        }
    }
}
