
using System;
using System.Collections.Generic;

namespace BlueGOAP
{
    /// <summary>
    /// �����ȶ����ӳ�������
    /// </summary>
    public interface IMaps<TAction, TGoal>
    {
        IActionHandler<TAction> GetActionHandler(TAction actionLabel);
        IGoal GetGoal(TGoal goalLabel);
    }

    public abstract class Maps<TAction, TGoal> : IMaps<TAction, TGoal>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _actionHandlerDic;
        private Dictionary<TGoal, IGoal> _goalsDic;

        public Maps()
        {
            _actionHandlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            _goalsDic = new Dictionary<TGoal, IGoal>();
            InitActinMaps();
        }

        /// <summary>
        /// �ڴ˺������ֶ���д��Ӧ�Ķ�������
        /// </summary>
        public abstract void InitActinMaps();

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="actionLabel"></param>
        /// <returns></returns>
        public IActionHandler<TAction> GetActionHandler(TAction actionLabel)
        {
            IActionHandler<TAction> map;
            _actionHandlerDic.TryGetValue(actionLabel, out map);
            if(map == null)
                DebugMsg.LogError("action:"+ actionLabel+" not init");
            return map;
        }
        /// <summary>
        /// ��ȡĿ������
        /// </summary>
        /// <param name="goalLabel"></param>
        /// <returns></returns>
        public IGoal GetGoal(TGoal goalLabel)
        {
            IGoal goal;
            _goalsDic.TryGetValue(goalLabel, out goal);
            if (goal == null)
                DebugMsg.LogError("goal:" + goalLabel + " not init");
            return goal;
        }
    }
}
