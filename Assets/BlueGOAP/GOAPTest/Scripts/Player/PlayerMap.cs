
using BlueGOAP;

namespace BlueGOAPTest
{
    public class PlayerMap : MapsBase<ActionEnum, GoalEnum>
    {
        public PlayerMap(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override void InitActinMaps()
        {
            AddAction<LookAtHandler, LookAtAction>();
        }

        protected override void InitGoalMaps()
        {
        }

        protected override void InitGameData()
        {
            SetGameData(DataName.SELF_TRANS, ObjectsInScene.Instance.Player);
            SetGameData(DataName.ENEMY_TRANS, ObjectsInScene.Instance.Enemy);
        }
    }
}
