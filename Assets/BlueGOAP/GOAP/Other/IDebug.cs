
namespace BlueGOAP
{
    public class DebugMsgBase
    {
        public static DebugMsgBase Instance { get; protected set; }

        public virtual void Log(string msg)
        {
            throw new System.NotImplementedException();
        }

        public virtual void LogWarning(string msg)
        {
            throw new System.NotImplementedException();
        }

        public virtual void LogError(string msg)
        {
            throw new System.NotImplementedException();
        }
    }

    public class DebugMsg
    {
        public static void Log(string msg)
        {
            DebugMsgBase.Instance.Log(msg);
        }

        public static void LogWarning(string msg)
        {
            DebugMsgBase.Instance.LogWarning(msg);
        }

        public static void LogError(string msg)
        {
            DebugMsgBase.Instance.LogError(msg);
        }
    }
}
