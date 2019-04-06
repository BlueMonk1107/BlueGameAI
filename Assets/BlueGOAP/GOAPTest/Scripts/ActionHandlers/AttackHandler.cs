
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
            DebugMsg.Log("½øÈë¹¥»÷×´Ì¬");
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
