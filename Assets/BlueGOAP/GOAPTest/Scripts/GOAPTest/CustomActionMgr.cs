
using BlueGOAP;

namespace BlueGOAPTest
{
    public class CustomActionMgr : ActionManagerBase<ActionEnum, GoalEnum>
    {
        public CustomActionMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override void InitActionHandlers()
        {
            throw new System.NotImplementedException();
        }
    }
}
