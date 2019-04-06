
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
        IGoal<TGoal> GetGoal(TGoal goalLabel);
    }

    public abstract class MapsBase<TAction, TGoal> : IMaps<TAction, TGoal>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _actionHandlerDic;
        private Dictionary<TGoal, IGoal<TGoal>> _goalsDic;

        public MapsBase()
        {
            _actionHandlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            _goalsDic = new Dictionary<TGoal, IGoal<TGoal>>();
            InitActinMaps();
            InitGoalMaps();
        }

        /// <summary>
        /// �ڴ˺������ֶ���д��Ӧ�Ķ�������
        /// </summary>
        protected abstract void InitActinMaps();
        /// <summary>
        /// �ڴ˺������ֶ���д��Ӧ��Ŀ������
        /// </summary>
        protected abstract void InitGoalMaps();

        protected void AddAction(IActionHandler<TAction> handler)
        {
            if (!_actionHandlerDic.ContainsKey(handler.Label))
            {
                _actionHandlerDic.Add(handler.Label, handler);
            }
            else
            {
                DebugMsg.LogError("Action Label name:"+ handler.Label+" is already in cache");
            }
        }

        protected void AddGoal(IGoal<TGoal> goal)
        {
            if (!_goalsDic.ContainsKey(goal.Label))
            {
                _goalsDic.Add(goal.Label,goal);
            }
            else
            {
                DebugMsg.LogError("Goal Label name:" + goal.Label + " is already in cache");
            }
        }

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
        public IGoal<TGoal> GetGoal(TGoal goalLabel)
        {
            IGoal<TGoal> goal;
            _goalsDic.TryGetValue(goalLabel, out goal);
            if (goal == null)
                DebugMsg.LogError("goal:" + goalLabel + " not init");
            return goal;
        }
    }
}
