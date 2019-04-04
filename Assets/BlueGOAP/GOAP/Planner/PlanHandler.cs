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

        public bool InProgress { get; private set; }

        public bool IsComplete {
            get { return _plan.Count == 0; }
        }

        public void Init(IActionManager<TAction> actionManager, Queue<IActionHandler<TAction>> plan)
        {
            _plan = plan;
            InProgress = false;
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
                InProgress = false;
                _onComplete();
            }
            else
            {
                InProgress = true;
                _actionManager.ChangeCurrentAction(_plan.Dequeue().Label);
            }
        }
    }
}
