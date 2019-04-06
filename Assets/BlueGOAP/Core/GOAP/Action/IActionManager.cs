
using System;
using System.Collections.Generic;

namespace BlueGOAP
{
    /// <summary>
    /// �¼�����
    /// </summary>
    public interface IActionManager<TAction>
    {
        /// <summary>
        /// �Ƿ�ִ�ж���
        /// </summary>
        bool IsPerformAction { get; set; }
        /// <summary>
        /// Ч���Ͷ�����ӳ���ϵ
        /// </summary>
        Dictionary<string, HashSet<IActionHandler<TAction>>> EffectsAndActionMap { get; }
        /// <summary>
        /// ��Ӵ��������
        /// </summary>
        void AddHandler(TAction actionLabel);
        /// <summary>
        /// �Ƴ����������
        /// </summary>
        /// <param name="handler"></param>
        void RemoveHandler(TAction actionLabel);
        /// <summary>
        /// ��ȡ���������
        /// </summary>
        /// <param name="handler"></param>
        IActionHandler<TAction> GetHandler(TAction actionLabel);
        /// <summary>
        /// ֡����
        /// </summary>
        void FrameFun();
        /// <summary>
        /// �ı䵱ǰִ�еĶ���
        /// </summary>
        /// <param name="actionLabel"></param>
        void ChangeCurrentAction(TAction actionLabel);
        /// <summary>
        /// ��Ӷ�����ɵļ���
        /// </summary>
        /// <param name="actionComplete"></param>
        void AddActionCompleteListener(Action actionComplete);
    }
}
