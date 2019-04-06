
using BlueGOAP;

namespace BlueGOAPTest
{
    public class MoveHandler : ActionHandlerBase<ActionEnum>
    {
        public MoveHandler(IAction<ActionEnum> action) : base(action)
        {
        }

        public override void Enter()
        {
            DebugMsg.Log("½øÈëÒÆ¶¯×´Ì¬");
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }
}
