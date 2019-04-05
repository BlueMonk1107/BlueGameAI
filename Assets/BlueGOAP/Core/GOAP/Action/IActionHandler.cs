using System;
using UnityEngine;

namespace BlueGOAP
{
    /// <summary>
    /// �¼�����ӿ�
    /// </summary>
    public interface IActionHandler<TAction> : IFsmState<TAction>
    {
        /// <summary>
        /// ����
        /// </summary>
        IAction<TAction> Action { get; }
        /// <summary>
        /// ��ǰ����������Ķ����ı�ǩ
        /// </summary>
        TAction Label { get; }
        /// <summary>
        /// �жϵ�ǰ״̬�Ƿ��ܹ�ִ�ж���
        /// </summary>
        /// <returns></returns>
        bool CanPerformAction();
        /// <summary>
        /// ��Ӷ�����ɻص�
        /// </summary>
        /// <param name="onFinishAction"></param>
        void AddFinishAction(System.Action onFinishAction);
    }
}
