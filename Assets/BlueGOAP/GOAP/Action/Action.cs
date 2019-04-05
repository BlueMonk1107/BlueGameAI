
namespace BlueGOAP
{
    public abstract class ActionBase<TAction, TGoal> : IAction<TAction>
    {
        public TAction Label { get; private set; }
        public int Cost { get; private set; }
        public int Precedence { get; private set; }

        /// <summary>
        /// 当前动作的代理
        /// </summary>
        protected IAgent<TAction, TGoal> _agent;

        /// <summary>
        /// 执行动作的先决条件
        /// </summary>
        protected IState _preconditions;

        /// <summary>
        /// 动作执行后的状态
        /// </summary>
        protected IState _effects;

        /// <summary>
        /// 当前动作是否能够中断
        /// </summary>
        protected bool _interruptible;

        protected System.Action _onFinishAction;

        public ActionBase(IAgent<TAction, TGoal> agent, TAction label)
        {
            Label = label;
            Cost = 1;
            Precedence = 0;
            _preconditions = InitPreconditions();
            _effects = InitEffects();
            _agent = agent;
        }

        public IState GetPreconditions()
        {
            return _preconditions;
        }

        public IState GetEffects()
        {
            return _effects;
        }
      
        /// <summary>
        /// 初始化先决条件
        /// </summary>
        /// <returns></returns>
        public abstract IState InitPreconditions();
        /// <summary>
        /// 初始化动作产生的影响
        /// </summary>
        /// <returns></returns>
        public abstract IState InitEffects();

        /// <summary>
        /// 验证先决条件
        /// </summary>
        /// <returns></returns>
        public bool VerifyPreconditions()
        {
            return _agent.AgentState.ContainState(_preconditions);
        }

        public void AddFinishAction(System.Action onFinishAction)
        {
            _onFinishAction = onFinishAction;
        }
    }
}
