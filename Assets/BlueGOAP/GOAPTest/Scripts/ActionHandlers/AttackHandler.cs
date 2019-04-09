
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AttackHandler  : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public AttackHandler(IAgent<ActionEnum, GoalEnum> agent,IAction<ActionEnum> action) : base(agent,action)
        {
        }

        public override void Enter()
        {
            DebugMsg.Log("进入攻击状态");
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
