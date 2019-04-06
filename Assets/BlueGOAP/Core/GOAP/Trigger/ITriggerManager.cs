
using System.Collections.Generic;

namespace BlueGOAP
{
    public interface ITriggerManager    
    {
        /// <summary>
        /// ֡����
        /// </summary>
        void FrameFun();
    }

    public abstract class TriggerManagerBase<TAction, TGoal> : ITriggerManager
    {
        protected IAgent<TAction, TGoal> _agent;
        private HashSet<ITrigger> _triggers; 

        public TriggerManagerBase(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
            _triggers = new HashSet<ITrigger>();
            InitTriggers();
        }

        public void FrameFun()
        {
            foreach (ITrigger trigger in _triggers)
            {
                trigger.FrameFun();
            }
        }

        protected void AddTrigger(ITrigger trigger)
        {
            _triggers.Add(trigger);
        }
        /// <summary>
        /// ������Ҫ��ӵĴ������ڴ˺����ڽ������
        /// </summary>
        protected abstract void InitTriggers();
    }
}
