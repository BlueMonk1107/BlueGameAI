
using BlueGOAP;

namespace BlueGOAPTest
{
    public class InjureAction : ActionBase<ActionEnum, GoalEnum>
    {
        public InjureAction(IAgent<ActionEnum, GoalEnum> agent, ActionEnum label) : base(agent, label)
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
