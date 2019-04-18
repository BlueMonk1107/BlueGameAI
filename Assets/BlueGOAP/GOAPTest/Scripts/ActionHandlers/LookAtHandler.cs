
using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class LookAtHandler : ActionHandlerBase<ActionEnum,GoalEnum>
    {
        private Transform _self, _enemy;

        public LookAtHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent, action)
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
