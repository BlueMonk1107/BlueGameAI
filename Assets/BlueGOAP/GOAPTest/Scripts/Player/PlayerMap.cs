
using System;
using BlueGOAP;

namespace BlueGOAPTest
{
    public class PlayerMap : MapsBase<ActionEnum, GoalEnum>
    {
        public PlayerMap(IAgent<ActionEnum, GoalEnum> agent, Action<IAgent<ActionEnum, GoalEnum>, IMaps<ActionEnum, GoalEnum>> onInitGameData) : base(agent, onInitGameData)
        {
        }

        protected override void InitActinMaps()
        {
            AddAction<LookAtStateHandler, LookAtActionState>();
        }

        protected override void InitGoalMaps()
        {
        }

        protected override void InitGameData(Action<IAgent<ActionEnum, GoalEnum>, IMaps<ActionEnum, GoalEnum>> onInitGameData)
        {
            base.InitGameData(onInitGameData);
            SetGameData(DataName.SELF_TRANS, ObjectsInScene.Instance.Player);
            SetGameData(DataName.ENEMY_TRANS, ObjectsInScene.Instance.Enemy);
        }


    }
}
