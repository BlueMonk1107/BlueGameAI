
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
            AddActionHandler(ActionEnum.ATTACK);
            AddActionHandler(ActionEnum.ALERT);
            AddActionHandler(ActionEnum.INJURE);
            AddActionHandler(ActionEnum.MOVE);
            AddActionHandler(ActionEnum.ATTACK_IDLE);
        }

        protected override void InitActionStateHandlers()
        {
            AddActionStateHandler(ActionEnum.LOOK_AT);
        }

        public override ActionEnum GetDefaultActionLabel()
        {
            return ActionEnum.ALERT;
        }
    }
}
