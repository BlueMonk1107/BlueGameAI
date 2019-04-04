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
        /// ��ȡID���붯��ID��ͬ��
        /// </summary>
        int ID { get; }
        /// <summary>
        /// �жϵ�ǰ״̬�Ƿ��ܹ�ִ�ж���
        /// </summary>
        /// <returns></returns>
        bool CanPerformAction();
    }
}
