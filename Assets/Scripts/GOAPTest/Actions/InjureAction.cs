
using BlueGOAP;

namespace BlueGOAPTest
{
    public class InjureAction : ActionBase<ActionEnum, GoalEnum>
    {
        public override ActionEnum Label { get { return ActionEnum.INJURE; } }
        public override int Cost { get { return 1; } }
        public override int Precedence { get { return 0; } }
        
        public InjureAction(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        protected override IState InitPreconditions()
        {
            throw new System.NotImplementedException();
        }

        protected override IState InitEffects()
        {
            throw new System.NotImplementedException();
        }


    }
}
