
using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class AttackIdleHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        private float _time;

        public AttackIdleHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入战斗待机状态");
            _time = 0;
            SetAgentState(KeyNameEnum.NEAR_ENEMY,false);
        }

        public override void Execute()
        {
            base.Execute();
            if (_time < 2)
            {
                _time += Time.fixedDeltaTime;
            }
            else
            {
                DebugMsg.Log("战斗待机状态完成");
                OnComplete();
            }
        }

        public override void Exit()
        {
            base.Exit();
            DebugMsg.Log("退出战斗待机状态");
        }

      
    }
}
