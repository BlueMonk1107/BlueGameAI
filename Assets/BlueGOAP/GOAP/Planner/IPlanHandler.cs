
using System;
using System.Collections.Generic;

namespace BlueGOAP
{
    public interface IPlanHandler<TAction>
    {
        /// <summary>
        /// �ƻ��Ƿ����ڽ�����
        /// </summary>
        bool InProgress { get; }
        /// <summary>
        /// ��ǰ�ƻ��Ƿ����
        /// </summary>
        bool IsComplete { get; }
        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="plan"></param>
        void Init(IActionManager<TAction> actionManager,Queue<IActionHandler<TAction>> plan);

        void AddCompleteCallBack(Action onComplete);
        /// <summary>
        /// ��ʼִ�мƻ�
        /// </summary>
        void StartPlan();
        /// <summary>
        /// ִ����һ������
        /// </summary>
        void NextAction();
    }
}
