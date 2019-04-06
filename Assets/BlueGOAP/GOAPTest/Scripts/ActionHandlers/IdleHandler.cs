
using BlueGOAP;

namespace BlueGOAPTest
{
    public class IdleHandler : ActionHandlerBase<ActionEnum>
    {
        public IdleHandler(IAction<ActionEnum> action) : base(action)
        {
        }

        public override void Enter()
        {
            DebugMsg.Log("�������״̬");
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }
}
