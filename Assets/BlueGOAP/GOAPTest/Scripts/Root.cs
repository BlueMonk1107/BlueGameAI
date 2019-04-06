using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class Root : MonoBehaviour
    {
        private Agent<ActionEnum, GoalEnum> _agent;

        public void Start()
        {
            _agent = new CustomAgent();
        }

        public void FixedUpdate()
        {
            _agent.FrameFun();
        }
    }
}
