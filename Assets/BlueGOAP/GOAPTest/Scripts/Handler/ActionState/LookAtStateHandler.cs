
using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class LookAtStateHandler : ActionHandlerBase<ActionEnum,GoalEnum>
    {
        private Transform _self, _enemy;

        public LookAtStateHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _self = _agent.Maps.GetGameData(DataName.SELF_TRANS) as Transform;
            _enemy = _agent.Maps.GetGameData(DataName.ENEMY_TRANS) as Transform;
        }

        public override void Execute()
        {
            base.Execute();
            _self.LookAt(_enemy);

            if (_agent.AgentState.Get(KeyNameEnum.FIND_ENEMY.ToString()) == false)
            {
                OnComplete();
            }
        }


    }
}
