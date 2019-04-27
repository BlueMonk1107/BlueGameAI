
using BlueGOAP;

namespace BlueGOAPTest
{
    public class PlayerActMgr : ActionManagerBase<ActionEnum, GoalEnum>
    {
        public PlayerActMgr(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override ActionEnum GetDefaultActionLabel()
        {
            return ActionEnum.IDLE;
        }

        protected override void InitActionHandlers()
        {
            
        }

        protected override void InitActionStateHandlers()
        {
            AddActionStateHandler(ActionEnum.LOOK_AT);
        }
    }
}
