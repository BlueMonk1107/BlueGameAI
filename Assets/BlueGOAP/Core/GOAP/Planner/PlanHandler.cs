using System;
using System.Collections;
using System.Collections.Generic;

namespace BlueGOAP
{
    public class PlanHandler<TAction> : IPlanHandler<TAction>
    {
        private Queue<IActionHandler<TAction>> _plan;
        private IActionManager<TAction> _actionManager;
        private Action _onComplete;
        private IActionHandler<TAction> _currentActionHandler;

        public bool IsComplete {
            get
            {
                if (_plan == null)
                {
                    return true;
                }

                if (_currentActionHandler == null)
                {
                    return _plan.Count == 0;
                }
                else
                {
                    return _currentActionHandler.IsComplete && _plan.Count == 0;
                }
            }
        }

        public void Init(IActionManager<TAction> actionManager, Queue<IActionHandler<TAction>> plan)
        {
            _currentActionHandler = null;
            _actionManager = actionManager;
            _plan = plan;
        }

        public void AddCompleteCallBack(Action onComplete)
        {
            _onComplete = onComplete;
        }

        public void StartPlan()
        {
            NextAction();
        }

        public void NextAction()
        {
            if (IsComplete)
            {
                _onComplete();
            }
            else
            {
                TAction label = _plan.Dequeue().Label;
                _currentActionHandler = _actionManager.GetHandler(label);
                DebugMsg.Log("----当前执行动作:"+ label);
                _actionManager.ChangeCurrentAction(label);
            }
        }
    }
}
