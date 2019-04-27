
using System;
using System.Threading.Tasks;
using BlueGOAP;

namespace BlueGOAPTest
{
    public class InjureHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        public InjureHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
        }

        public async override void Enter()
        {
            DebugMsg.Log("进入受伤状态");
            //模拟受伤状态的延时时间
            await Task.Delay(TimeSpan.FromSeconds(2));
            OnComplete();
        }
    }
}
