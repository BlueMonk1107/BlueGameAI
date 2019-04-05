
using BlueGOAP;
using UnityEngine;

namespace BlueGOAPTest
{
    public class CustomDebug : DebugMsgBase
    {
        public CustomDebug()
        {
            Instance = this;
        }
        public override void Log(string msg)
        {
            Debug.Log(msg);
        }

        public override void LogWarning(string msg)
        {
            Debug.LogWarning(msg);
        }

        public override void LogError(string msg)
        {
            Debug.LogError(msg);
        }
    }
}
