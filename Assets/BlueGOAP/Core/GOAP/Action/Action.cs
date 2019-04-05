
namespace BlueGOAP
{
    public abstract class ActionBase<TAction, TGoal> : IAction<TAction>
    {
        public abstract TAction Label { get; }
        public abstract int Cost { get; }
        public abstract int Precedence { get;}

        /// <summary>
        /// ִ�ж������Ⱦ�����
        /// </summary>
        public IState Preconditions { get; private set; }

        /// <summary>
        /// ����ִ�к��״̬
        /// </summary>
        public IState Effects { get; private set; }

        /// <summary>
        /// ��ǰ�����Ĵ���
        /// </summary>
        protected IAgent<TAction, TGoal> _agent;
        
        /// <summary>
        /// ��ǰ�����Ƿ��ܹ��ж�
        /// </summary>
        protected bool _interruptible;

        protected System.Action _onFinishAction;

        public ActionBase(IAgent<TAction, TGoal> agent)
        {
            Preconditions = InitPreconditions();
            Effects = InitEffects();
            _agent = agent;
        }

        /// <summary>
        /// ��ʼ���Ⱦ�����
        /// </summary>
        /// <returns></returns>
        protected abstract IState InitPreconditions();

        /// <summary>
        /// ��ʼ������������Ӱ��
        /// </summary>
        /// <returns></returns>
        protected abstract IState InitEffects();

        /// <summary>
        /// ��֤�Ⱦ�����
        /// </summary>
        /// <returns></returns>
        public bool VerifyPreconditions()
        {
            return _agent.AgentState.ContainState(Preconditions);
        }

        public void AddFinishAction(System.Action onFinishAction)
        {
            _onFinishAction = onFinishAction;
        }
    }
}
