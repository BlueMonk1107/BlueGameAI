using System;
using System.Collections;

namespace BlueGOAP
{
    public interface IGoal
    {
        /// <summary>
        /// 比较Goal的优先级
        /// </summary>
        /// <param name="otherGoal"></param>
        /// <returns></returns>
        int CompareTo(IGoal otherGoal);
        /// <summary>
        /// 获取优先级
        /// </summary>
        /// <returns></returns>
        float GetPriority();
        /// <summary>
        /// 获取目标对状态的影响
        /// </summary>
        /// <returns></returns>
        IState GetEffects();
        /// <summary>
        /// 是否已经实现目标
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        bool IsGoalAchieved(IState state);
        /// <summary>
        /// 添加目标激活的监听
        /// </summary>
        /// <param name="onActivate"></param>
        void AddGoalActivateListener(Action<IGoal> onActivate);
        /// <summary>
        /// 添加目标未激活的监听
        /// </summary>
        /// <param name="onInactivate"></param>
        void AddGoalInactivateListener(Action<IGoal> onInactivate);

        void Update();
    }
}
