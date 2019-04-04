
namespace BlueGOAP
{
    public abstract class Agent<TAction, TGoal> : IAgent<TAction, TGoal> 
        where TAction : struct 
        where TGoal   : struct
    {
        public IState AgentState { get; private set; }
        public IMaps<TAction, TGoal> Maps { get; protected set; }
        public IActionManager<TAction> ActionManager { get; protected set; }
        public IGoalManager<TGoal> GoalManager { get; private set; }
        public IPerformer Performer { get; private set; }

        public Agent()
        {
            AgentState = new State();
            Maps = InitMaps();
            Performer = new Performer<TAction, TGoal>(this);
            ActionManager = InitActionManager();
            GoalManager = InitGoalManager();

            AgentState.AddStateChangeListener(UpdateData);
        }

        protected abstract IMaps<TAction, TGoal> InitMaps();
        protected abstract IActionManager<TAction> InitActionManager();
        protected abstract IGoalManager<TGoal> InitGoalManager();

        public void UpdateData()
        {
            if (GoalManager != null)
                GoalManager.UpdateData();

            Performer.UpdateData();
        }

        public virtual void FrameFun()
        {
            if(ActionManager != null)
                ActionManager.FrameFun();
        }
    }
}
