using System.Collections.Generic;

namespace BlueGOAP
{
    public interface IPlanner<TAction, TGoal>
    {
        /// <summary>
        /// ��ȡ��ǰ�Ķ���
        /// </summary>
        /// <returns></returns>
        IAction<TAction> GetCurrentAction();
        /// <summary>
        /// �ƻ�
        /// </summary>
        Queue<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal);
        /// <summary>
        /// �Ƿ���ɼƻ�
        /// </summary>
        /// <returns></returns>
        bool IsFinish();
        /// <summary>
        /// �жϼƻ�
        /// </summary>
        void Interruptible();
    }
}
