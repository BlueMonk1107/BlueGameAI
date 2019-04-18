
using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController _controller;
        private float _speed = 5;
        private IAgent<ActionEnum, GoalEnum> _enemyAgent;
        public void Start()
        {
            _controller = GetComponent<CharacterController>();
            _enemyAgent = ObjectsInScene.Instance.Enemy.GetComponent<Root>().Agent;
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _controller.SimpleMove(Vector3.forward * _speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _controller.SimpleMove(Vector3.back * _speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _controller.SimpleMove(Vector3.left * _speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _controller.SimpleMove(Vector3.right * _speed);
            }
            if (Input.GetKey(KeyCode.K))
            {
                _enemyAgent.AgentState.Set(KeyNameEnum.INJURE.ToString(), true);
            }
        }
    }
}
