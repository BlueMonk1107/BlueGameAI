using System;
using System.Collections;

namespace BlueGOAP
{
    public interface IGoal
    {
        /// <summary>
        /// �Ƚ�Goal�����ȼ�
        /// </summary>
        /// <param name="otherGoal"></param>
        /// <returns></returns>
        int CompareTo(IGoal otherGoal);
        /// <summary>
        /// ��ȡ���ȼ�
        /// </summary>
        /// <returns></returns>
        float GetPriority();
        /// <summary>
        /// ��ȡĿ���״̬��Ӱ��
        /// </summary>
        /// <returns></returns>
        IState GetEffects();
        /// <summary>
        /// �Ƿ��Ѿ�ʵ��Ŀ��
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        bool IsGoalAchieved(IState state);
        /// <summary>
        /// ���Ŀ�꼤��ļ���
        /// </summary>
        /// <param name="onActivate"></param>
        void AddGoalActivateListener(Action<IGoal> onActivate);
        /// <summary>
        /// ���Ŀ��δ����ļ���
        /// </summary>
        /// <param name="onInactivate"></param>
        void AddGoalInactivateListener(Action<IGoal> onInactivate);

        void Update();
    }
}
