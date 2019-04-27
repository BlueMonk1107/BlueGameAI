
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AttackHandler  : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public AttackHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入攻击状态");
            OnComplete();
        }

      
    }
}
