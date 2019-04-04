using System;
using System.Collections;

namespace BlueGOAP
{
    public abstract class Goal<TAction, TGoal> : IGoal
    {
        private IAgent<TAction, TGoal> _agent;
        private Action<IGoal> _onActivate;
        private Action<IGoal> _onInactivate;
        private bool _lastActiveState;

        public Goal(IAgent<TAction, TGoal> agent)
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
        /// �Ƿ��Ѿ�ʵ��Ŀ��
        /// </summary>
        public abstract bool IsGoalAchieved(IState state);

        public void AddGoalActivateListener(Action<IGoal> onActivate)
        {
            _onActivate = onActivate;
        }

        public void AddGoalInactivateListener(Action<IGoal> onInactivate)
        {
            _onInactivate = onInactivate;
        }

        public void Update()
        {
            if (IsSatisfyActiveCondition() != _lastActiveState)
            {
                _lastActiveState = IsSatisfyActiveCondition();
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
        /// �жϵ�ǰ��Goal�Ƿ����㼤������
        /// </summary>
        /// <returns></returns>
        protected abstract bool IsSatisfyActiveCondition();

        public int CompareTo(IGoal otherGoal)
        {
            return GetPriority() - otherGoal.GetPriority() > 0 ? 1 : -1;
        }
    }
}
