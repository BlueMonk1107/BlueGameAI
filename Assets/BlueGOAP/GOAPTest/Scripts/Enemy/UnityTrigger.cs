
using System;
using UnityEngine;

namespace BlueGOAPTest
{
    public class UnityTrigger : MonoBehaviour
    {
        private Action<Collider> _collideCallBack;

        public void AddCollideCallBack(Action<Collider> collideCallBack)
        {
            _collideCallBack = collideCallBack;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_collideCallBack != null)
                _collideCallBack(other);
        }
    }
}
