using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class Root : MonoBehaviour
    {
        Agent<ActionEnum, GoalEnum> agent = new CustomAgent();
    }
}
