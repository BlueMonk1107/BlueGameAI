
using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class PlayerRoot : MonoBehaviour
    {
        public IAgent<ActionEnum, GoalEnum> Agent { get; private set; }

        private void Start()
        {
            Agent = new PlayerAgent();
        }

        private void FixedUpdate()
        {
            Agent.FrameFun();
        }

    }
}
