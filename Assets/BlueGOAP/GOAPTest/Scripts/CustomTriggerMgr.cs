
using BlueGOAP;

namespace BlueGOAPTest
{
    public class CustomTriggerMgr : TriggerManagerBase<ActionEnum, GoalEnum>
    {
        public CustomTriggerMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override void InitTriggers()
        {
            AddTrigger(new TriggerEyes(_agent));
        }
    }
}
