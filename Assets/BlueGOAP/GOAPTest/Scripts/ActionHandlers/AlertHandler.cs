
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AlertHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public AlertHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent, action)
        {
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入警戒状态");

            OnComplete();
        }

        public override void Exit()
        {
            DebugMsg.Log("退出警戒状态");
        }
    }
}
