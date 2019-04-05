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
        /// 获取目标对状态的影响
        /// </summary>
        public abstract IState GetEffects();

        /// <summary>
        /// 是否已经实现目标
        /// </summary>
        public abstract bool IsGoalAchieved(IState state);

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
        /// 判断当前的Goal是否满足激活条件
        /// </summary>
        /// <returns></returns>
        protected abstract bool IsSatisfyActiveCondition();

        public int CompareTo(IGoal<TGoal> otherGoal)
        {
            return GetPriority() - otherGoal.GetPriority() > 0 ? 1 : -1;
        }
    }
}
