
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
            AddHandler(ActionEnum.ATTACK);
            AddHandler(ActionEnum.ALERT);
            AddHandler(ActionEnum.INJURE);
            AddHandler(ActionEnum.MOVE);
            AddHandler(ActionEnum.ATTACK_IDLE);
        }

        protected override void InitMutilActionHandlers()
        {
            AddMutilActionHandler(ActionEnum.LOOK_AT);
        }

        public override ActionEnum GetDefaultActionLabel()
        {
            return ActionEnum.ALERT;
        }
    }
}
