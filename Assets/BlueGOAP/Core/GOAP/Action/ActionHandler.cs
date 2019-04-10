
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

        public TAction Label
        {
            get { return Action.Label; }
        }

        public bool IsComplete { get; private set; }

        protected IAgent<TAction, TGoal> _agent;
        private IAction<ActionEnum> action;
        protected System.Action _onFinishAction;

        public ActionHandlerBase(IAgent<TAction, TGoal> agent, IAction<TAction> action)
        {
            _agent = agent;
            Action = action;
            IsComplete = false;
        }

        private void SetAgentData(IState state)
        {
            _agent.AgentState.SetData(state);
        }

        protected void SetAgentState<TKey>(TKey key,bool value)
        {
            _agent.AgentState.SetState(key.ToString(),value);
        }

        protected void OnComplete()
        {
            IsComplete = true;

            if (_onFinishAction != null)
                _onFinishAction();

            SetAgentData(Action.Effects);
            SetAgentData(Action.Preconditions.InversionValue());
        }

        public bool CanPerformAction()
        {
            DebugMsg.Log("Action:"+ Action.Label);
            return Action.VerifyPreconditions();
        }

        public void AddFinishAction(Action onFinishAction)
        {
            _onFinishAction = onFinishAction;
        }

        public virtual void Enter()
        {
            IsComplete = false;
        }

        public virtual void Execute()
        {

        }

        public virtual void Exit()
        {
            
        }

    }
}
