
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AttackHandler  : ActionHandlerBase<ActionEnum>
    {
        public AttackHandler(IAction<ActionEnum> action) : base(action)
        {
        }

        public override void Enter()
        {
            DebugMsg.Log("���빥��״̬");
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
