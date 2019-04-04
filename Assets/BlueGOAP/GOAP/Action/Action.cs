
namespace BlueGOAP
{
    public abstract class Action<TAction, TGoal> : IAction<TAction>
    {
        private static int _idCounter  = -1;
        public int ID { get; private set; }
        public int Cost { get; private set; }
        public int Precedence { get; private set; }

        /// <summary>
        /// ��ǰ�����Ĵ���
        /// </summary>
        protected IAgent<TAction, TGoal> _agent;

        /// <summary>
        /// ִ�ж������Ⱦ�����
        /// </summary>
        protected IState _preconditions;

        /// <summary>
        /// ����ִ�к��״̬
        /// </summary>
        protected IState _effects;

        /// <summary>
        /// ��ǰ�����Ƿ��ܹ��ж�
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
        /// ��֤�Ⱦ�����
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
