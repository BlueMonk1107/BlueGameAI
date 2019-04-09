
using BlueGOAP;

namespace BlueGOAPTest
{
    public class MoveHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public MoveHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent,action)
        {
        }

        public override void Enter()
        {
            DebugMsg.Log("进入移动状态");
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }
}
