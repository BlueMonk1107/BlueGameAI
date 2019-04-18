
using BlueGOAP;

namespace BlueGOAPTest
{
    public class AttackGoal : GoalBase<ActionEnum,GoalEnum>
    {
        public override GoalEnum Label
        {
            get { return GoalEnum.ATTACK; }
        }

        public AttackGoal(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
        }

        public override float GetPriority()
        {
            return 4;
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.Set(KeyNameEnum.ATTACK_IDLE, true);
            return effects;
        }

        protected override bool ActiveCondition()
        {
            return GetAgentState(KeyNameEnum.FIND_ENEMY) == true
                && GetAgentState(KeyNameEnum.ATTACK_IDLE) == false;
        }
    }
}
