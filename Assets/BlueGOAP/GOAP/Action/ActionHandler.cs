
namespace BlueGOAP
{
    public abstract class ActionHandler<TAction> : IActionHandler<TAction>
    {
        /// <summary>
        /// ������ǩ
        /// </summary>
        public TAction Label { get; private set; }
        /// <summary>
        /// ����
        /// </summary>
        public IAction<TAction> Action { get; private set; }

        public int ID {
            get { return Action.ID; }
        }

        public bool CanPerformAction()
        {
            return Action.VerifyPreconditions();
        }

        public ActionHandler(TAction actionLabel, IAction<TAction> action)
        {
            Label = actionLabel;
            Action = action;
        }

        public abstract void Enter();

        public abstract void Execute();

        public abstract void Exit();
        
    }
}
