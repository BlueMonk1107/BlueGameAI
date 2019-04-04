using System.Collections.Generic;

namespace BlueGOAP
{
    public interface IPlanner<TAction>
    {
        /// <summary>
        /// 获取当前的动作
        /// </summary>
        /// <returns></returns>
        IAction<TAction> GetCurrentAction();
        /// <summary>
        /// 计划
        /// </summary>
        Queue<IActionHandler<TAction>> BuildPlan(IGoal goal);
        /// <summary>
        /// 是否完成计划
        /// </summary>
        /// <returns></returns>
        bool IsFinish();
        /// <summary>
        /// 中断计划
        /// </summary>
        void Interruptible();
    }
}
