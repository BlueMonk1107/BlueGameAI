
namespace BlueGOAP
{
    public interface IAgent<TAction, TGoal>
    {
        /// <summary>
        /// ��ǰ״̬
        /// </summary>
        IState AgentState { get; }
        /// <summary>
        /// ��ȡӳ�����ݶ���
        /// </summary>
        /// <returns></returns>
        IMaps<TAction, TGoal> Maps { get; }
        /// <summary>
        /// ��ȡ�������������
        /// </summary>
        /// <returns></returns>
        IActionManager<TAction> ActionManager { get; }
        /// <summary>
        /// ��ȡĿ����������
        /// </summary>
        /// <returns></returns>
        IGoalManager<TGoal> GoalManager { get; }
        /// <summary>
        /// �������ݺ���
        /// </summary>
        void UpdateData();
        /// <summary>
        /// ֡����
        /// </summary>
        void FrameFun();
    }
}
