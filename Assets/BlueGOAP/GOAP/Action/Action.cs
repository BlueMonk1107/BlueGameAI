
namespace BlueGOAP
{
    public abstract class ActionBase<TAction, TGoal> : IAction<TAction>
    {
        public TAction Label { get; private set; }
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
        /// ��ʼ���Ⱦ�����
        /// </summary>
        /// <returns></returns>
        public abstract IState InitPreconditions();
        /// <summary>
        /// ��ʼ������������Ӱ��
        /// </summary>
        /// <returns></returns>
        public abstract IState InitEffects();

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
