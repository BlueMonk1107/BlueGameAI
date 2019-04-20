
using BlueGOAP;

namespace BlueGOAPTest
{
    public class IdleHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public IdleHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent, action)
        {
            IsNeedResetPreconditions = false;
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入待机状态");
        }
    }
}
