
namespace BlueGOAP
{
    public interface IGoalManager<TGoal>
    {
        IGoal CurrentGoal { get; }
        void AddGoal(TGoal goalLabel);
        void RemoveGoal(TGoal goalLabel);
        IGoal GetGoal(TGoal goalLabel);
        IGoal FindGoal();
        void UpdateData();
    }
}
