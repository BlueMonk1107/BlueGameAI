using System;
using System.Collections;

namespace BlueGOAP
{
    public abstract class GoalBase<TAction, TGoal> : IGoal<TGoal>
    {
        private IAgent<TAction, TGoal> _agent;
        private Action<IGoal<TGoal>> _onActivate;
        private Action<IGoal<TGoal>> _onInactivate;
        private bool _lastActiveState;

        public abstract TGoal Label { get;}

        public GoalBase(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
            _lastActiveState = false;
        }

        public virtual float GetPriority()
        {
            return 1;
        }

        /// <summary>
        /// ��ȡĿ���״̬��Ӱ��
        /// </summary>
        public abstract IState GetEffects();

        /// <summary>
        /// ��ȡ����״̬��ֵ
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected bool GetAgentStateValue<Tkey>(Tkey key)
        {
            return _agent.AgentState.GetValue(key.ToString());
        }

        /// <summary>
        /// �Ƿ��Ѿ�ʵ��Ŀ��
        /// </summary>
        public abstract bool IsGoalComplete();

        public void AddGoalActivateListener(Action<IGoal<TGoal>> onActivate)
        {
            _onActivate = onActivate;
        }

        public void AddGoalInactivateListener(Action<IGoal<TGoal>> onInactivate)
        {
            _onInactivate = onInactivate;
        }

        public void Update()
        {
            if (ActiveCondition() != _lastActiveState)
            {
                _lastActiveState = ActiveCondition();
                if (_lastActiveState)
                {
                    _onActivate(this);
                }
                else
                {
                    _onInactivate(this);
                }
            }
        }
        /// <summary>
        /// ��ǰGoal�ļ�������
        /// </summary>
        /// <returns></returns>
        protected abstract bool ActiveCondition();

        public int CompareTo(IGoal<TGoal> otherGoal)
        {
            return GetPriority() - otherGoal.GetPriority() > 0 ? 1 : -1;
        }
    }
}
