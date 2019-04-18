
using BlueGOAP;

namespace BlueGOAPTest
{
    public class InjureGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public override GoalEnum Label
        {
            get { return GoalEnum.INJURE; }
        }

        public InjureGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override float GetPriority()
        {
            return 10;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.Set(KeyNameEnum.INJURE, false);
            return effects;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentState(KeyNameEnum.INJURE) == true;
        }
    }
}
