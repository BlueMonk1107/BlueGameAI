using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class Root : MonoBehaviour
    {
        public Agent<ActionEnum, GoalEnum> Agent { get; private set; }

        public void Start()
        {
            Agent = new CustomAgent();
            gameObject.AddComponent<UnityTrigger>().AddCollideCallBack(UnityTriggerCallBack);
        }

        public void FixedUpdate()
        {
            Agent.FrameFun();
        }

        /// <summary>
        /// 这里响应unity中的碰撞事件
        /// </summary>
        /// <param name="collider"></param>
        private void UnityTriggerCallBack(Collider collider)
        {
            
        }
    }
}
