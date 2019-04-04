using System.Collections.Generic;

namespace BlueGOAP
{
    public interface IPlanner<TAction>
    {
        /// <summary>
        /// ��ȡ��ǰ�Ķ���
        /// </summary>
        /// <returns></returns>
        IAction<TAction> GetCurrentAction();
        /// <summary>
        /// �ƻ�
        /// </summary>
        Queue<IActionHandler<TAction>> BuildPlan(IGoal goal);
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
