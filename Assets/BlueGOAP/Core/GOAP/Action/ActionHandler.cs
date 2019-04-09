
using System;
using BlueGOAPTest;

namespace BlueGOAP
{
    public abstract class ActionHandlerBase<TAction, TGoal> : IActionHandler<TAction>
    {
        /// <summary>
        /// 动作
        /// </summary>
        public IAction<TAction> Action { get; private set; }

        public TAction Label {
            get { return Action.Label; }
        }

        protected IAgent<TAction, TGoal> _agent;
        private IAction<ActionEnum> action;
        protected System.Action _onFinishAction;

        public ActionHandlerBase(IAgent<TAction, TGoal> agent,IAction<TAction> action)
        {
            _agent = agent;
            Action = action;
        }

        protected void SetAgentState<TKey>(TKey key,bool value)
        {
            _agent.AgentState.SetState(key.ToString(), value);
        }

        public bool CanPerformAction()
        {
            return Action.VerifyPreconditions();
        }

        public void AddFinishAction(Action onFinishAction)
        {
            _onFinishAction = onFinishAction;
        }

        public abstract void Enter();

        public abstract void Execute();

        public abstract void Exit();
        
    }
}
