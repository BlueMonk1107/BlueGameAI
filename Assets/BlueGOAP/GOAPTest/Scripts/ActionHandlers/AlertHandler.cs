
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AlertHandler : ActionHandlerBase<ActionEnum,GoalEnum>
    {
        public AlertHandler(IAgent<ActionEnum, GoalEnum> agent, IAction<ActionEnum> action) : base(agent, action)
        {
        }

        public override void Enter()
        {
            DebugMsg.Log("进入警戒状态");
           
            if(_onFinishAction != null)
                _onFinishAction();
            
            SetAgentState(KeyNameEnum.LOOK_AT_ENEMY, true);
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            
        }

       
    }
}
