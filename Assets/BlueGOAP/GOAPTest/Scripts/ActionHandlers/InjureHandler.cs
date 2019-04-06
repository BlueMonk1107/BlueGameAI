
using BlueGOAP;

namespace BlueGOAPTest
{
    public class InjureHandler : ActionHandlerBase<ActionEnum>
    {
        public InjureHandler(IAction<ActionEnum> action) : base(action)
        {
        }

        public override void Enter()
        {
            DebugMsg.Log("��������״̬");
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }
}
