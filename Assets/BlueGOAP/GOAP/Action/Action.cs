
namespace BlueGOAP
{
    public abstract class Action<TAction, TGoal> : IAction<TAction>
    {
        private static int _idCounter  = -1;
        public int ID { get; private set; }
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

        public Action(IAgent<TAction, TGoal> agent)
        {
            _idCounter++;
            ID = _idCounter;
            Cost = 1;
            Precedence = 0;
            _preconditions = new State();
            _effects = new State();
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
