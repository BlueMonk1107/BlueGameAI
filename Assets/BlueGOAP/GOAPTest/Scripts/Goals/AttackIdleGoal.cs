
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AttackIdleGoal : GoalBase<ActionEnum, GoalEnum>
    {
        public AttackIdleGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override GoalEnum Label
        {
            get { return GoalEnum.ATTACK_IDLE; }
        }

        public override float GetPriority()
        {
            return 2;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.Set(KeyNameEnum.MOVE, true);
            return effects;
        }


        protected override bool ActiveCondition()
        {
            return GetAgentState(KeyNameEnum.ATTACK_IDLE) == true;
        }
    }
}
