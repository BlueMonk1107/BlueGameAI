
using UnityEngine;

namespace BlueGOAPTest
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController _controller;
        private float _speed = 5;
        public void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _controller.SimpleMove(Vector3.forward* _speed);
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
        }
    }
}
