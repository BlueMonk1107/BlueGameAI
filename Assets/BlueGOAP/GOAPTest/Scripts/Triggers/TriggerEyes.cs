
using System;
using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class TriggerEyes : TriggerBase<ActionEnum, GoalEnum>
    {
        private Transform _self, _enemy;

        public TriggerEyes(IAgent<ActionEnum, GoalEnum> agent) : base(agent)
        {
            _self = (Transform)agent.Maps.GetGameData(DataName.SELF_TRANS);
            _enemy = (Transform)agent.Maps.GetGameData(DataName.ENEMY_TRANS);
        }

        public override bool IsTrigger
        {
            get
            {
                if (Vector3.Distance(_self.position, _enemy.position) < 5)
                {
                    Vector3 dirToEnemy = (_enemy.position - _self.position).normalized;
                    if (Vector3.Angle(_self.forward, dirToEnemy) < 60)
                    {
                        return true;
                    }
                }

                return false;
            }
            set { }
        }

        protected override IState InitEffects()
        {
            State<KeyNameEnum> effects = new State<KeyNameEnum>();
            effects.SetState(KeyNameEnum.FIND_ENEMY, true);
            return effects;
        }
    }
}
