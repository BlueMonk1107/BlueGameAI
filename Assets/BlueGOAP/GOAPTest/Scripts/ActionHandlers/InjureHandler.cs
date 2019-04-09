
using BlueGOAP;

namespace BlueGOAPTest
{
    public class InjureHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public InjureHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent,action)
        {
        }

        public override void Enter()
        {
            DebugMsg.Log("进入受伤状态");
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }
}
