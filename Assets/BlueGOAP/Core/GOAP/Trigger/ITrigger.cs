

namespace BlueGOAP
{
    /// <summary>
    /// �������ӿ�
    /// ������Ӧ������AI��Ӱ��
    /// </summary>
    public interface ITrigger
    {
        /// <summary>
        /// �Ƿ񴥷�
        /// </summary>
        bool IsTrigger { get; set; }
        /// <summary>
        /// ֡����
        /// </summary>
        void FrameFun();
    }

    public abstract class TriggerBase<TAction, TGoal> : ITrigger
    {
        private IState _effects;
        private IAgent<TAction, TGoal> _agent;

        public TriggerBase(IAgent<TAction, TGoal> agent)
        {
            _effects = InitEffects();
            _agent = agent;
        }

        public void FrameFun()
        {
            if (IsTrigger)
            {
                _agent.AgentState.SetData(_effects);
            }
        }

        /// <summary>
        /// �ж��Ƿ����㴥������
        /// </summary>
        public abstract bool IsTrigger { get; set; }

        protected abstract IState InitEffects();
    }
}
