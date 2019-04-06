
using UnityEngine;

namespace BlueGOAPTest
{
    public class ObjectsInScene : MonoBehaviour
    {
        public static ObjectsInScene Instance { get; set; }

        public Transform Player;
        public Transform Enemy;

        private void Awake()
        {
            Instance = this;
        }
    }
}
