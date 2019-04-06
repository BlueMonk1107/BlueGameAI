using System;
using System.Collections;

namespace BlueGOAP
{
    public interface IGoal<TGoal>
    {
        /// <summary>
        /// Ŀ��ı�ǩ
        /// </summary>
        TGoal Label { get; }
        /// <summary>
        /// �Ƚ�Goal�����ȼ�
        /// </summary>
        /// <param name="otherGoal"></param>
        /// <returns></returns>
        int CompareTo(IGoal<TGoal> otherGoal);
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
        /// <returns></returns>
        bool IsGoalComplete();
        /// <summary>
        /// ���Ŀ�꼤��ļ���
        /// </summary>
        /// <param name="onActivate"></param>
        void AddGoalActivateListener(Action<IGoal<TGoal>> onActivate);
        /// <summary>
        /// ���Ŀ��δ����ļ���
        /// </summary>
        /// <param name="onInactivate"></param>
        void AddGoalInactivateListener(Action<IGoal<TGoal>> onInactivate);

        void Update();
    }
}
