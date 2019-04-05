
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueGOAP
{
    public abstract class ActionManagerBase<TAction, TGoal> : IActionManager<TAction>
    {
        private Dictionary<TAction, IActionHandler<TAction>> _handlerDic;
        private IFSM<TAction> _fsm;
        private IAgent<TAction, TGoal> _agent;
        //效果的键值和动作的映射关系
        public bool IsPerformAction { get; set; }
        public Dictionary<object, HashSet<IActionHandler<TAction>>> EffectsAndActionMap { get; private set; }
        private Action _onActionComplete;

        public ActionManagerBase(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
            _handlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            _fsm = new FSM<TAction>();
            InitActionHandlers();
            InitFsm();
            InitEffectsAndActionMap();
        }

        /// <summary>
        /// 初始化当前代理的动作处理器
        /// </summary>
        protected abstract void InitActionHandlers();

        private void InitEffectsAndActionMap()
        {
            EffectsAndActionMap = new Dictionary<object, HashSet<IActionHandler<TAction>>>();

            foreach (var handler in _handlerDic)
            {
                IState state = handler.Value.Action.Effects;
                foreach (object key in state.GetKeys())
                {
                    if (EffectsAndActionMap[key] == null)
                        EffectsAndActionMap[key] = new HashSet<IActionHandler<TAction>>();

                    EffectsAndActionMap[key].Add(handler.Value);
                }
            }
        }

        public void AddHandler(TAction actionLabel)
        {
            var handler = _agent.Maps.GetActionHandler(actionLabel);
            if (handler != null)
            {
                _handlerDic.Add(actionLabel, handler);
                handler.AddFinishAction(_onActionComplete);
            }
        }

        public void RemoveHandler(TAction actionLabel)
        {
            _handlerDic.Remove(actionLabel);
        }

        public IActionHandler<TAction> GetHandler(TAction actionLabel)
        {
            if (_handlerDic.ContainsKey(actionLabel))
            {
                return _handlerDic[actionLabel];
            }

            DebugMsg.LogError("Not add action name:" + actionLabel);
            return null;
        }

        public void FrameFun()
        {
            if (IsPerformAction)
                _fsm.FrameFun();
        }

        public void ChangeCurrentAction(TAction actionLabel)
        {
            _fsm.ChangeState(actionLabel);
        }

        public void AddActionCompleteListener(Action actionComplete)
        {
            _onActionComplete = actionComplete;
        }

        private void InitFsm()
        {
            foreach (KeyValuePair<TAction, IActionHandler<TAction>> handler in _handlerDic)
            {
                _fsm.AddState(handler.Key, handler.Value);
            }
        }
    }
}
