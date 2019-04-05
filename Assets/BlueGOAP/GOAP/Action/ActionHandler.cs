
using System;

namespace BlueGOAP
{
    public abstract class ActionHandlerBase<TAction> : IActionHandler<TAction>
    {
        /// <summary>
        /// ¶¯×÷
        /// </summary>
        public IAction<TAction> Action { get; private set; }

        public TAction Label {
            get { return Action.Label; }
        }

        public ActionHandlerBase(IAction<TAction> action)
        {
            Action = action;
        }

        public bool CanPerformAction()
        {
            return Action.VerifyPreconditions();
        }

        public void AddFinishAction(Action onFinishAction)
        {
            Action.AddFinishAction(onFinishAction);
        }

        public abstract void Enter();

        public abstract void Execute();

        public abstract void Exit();
        
    }
}
