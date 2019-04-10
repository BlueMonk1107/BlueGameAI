
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

        public override IState GetEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.INJURE, false);
            return effects;
        }

        public override bool IsGoalComplete()
        {
            return GetAgentStateValue(KeyNameEnum.INJURE) == false;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentStateValue(KeyNameEnum.INJURE) == true;
        }
    }
}
