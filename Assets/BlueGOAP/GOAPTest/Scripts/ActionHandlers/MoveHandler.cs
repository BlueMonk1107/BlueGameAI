
using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class MoveHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        private Transform _self, _enemy;
        private CharacterController _controller;
        private float _speed = 4;
        public MoveHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent,action)
        {
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入移动状态");
            _self = (Transform)_agent.Maps.GetGameData(DataName.SELF_TRANS);
            _enemy = (Transform)_agent.Maps.GetGameData(DataName.ENEMY_TRANS);
            _controller = _self.GetComponent<CharacterController>();
        }

        public override void Execute()
        {
            base.Execute();
            if (Vector3.Distance(_self.position, _enemy.position)>1.5f)
            {
                Vector3 dirToEnemy = (_enemy.position - _self.position).normalized;
                _controller.SimpleMove(dirToEnemy * _speed);
            }
            else
            {
                OnComplete();
            }
        }

        public override void Exit()
        {
            base.Exit();
            DebugMsg.Log("退出移动状态");
        }
    }
}
