
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AttackHandlerBase  : ActionHandlerBase<ActionEnum>
    {
        public AttackHandlerBase(IAction<ActionEnum> action) : base(action)
        {
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
