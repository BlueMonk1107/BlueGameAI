
using BlueGOAP;

namespace BlueGOAPTest
{
    public class MoveAction : ActionBase<ActionEnum, GoalEnum>
    {
        public MoveAction(IAgent<ActionEnum, GoalEnum> agent, ActionEnum label) : base(agent, label)
        {
        }

        public override IState InitPreconditions()
        {
            throw new System.NotImplementedException();
        }

        public override IState InitEffects()
        {
            throw new System.NotImplementedException();
        }
    }
}
