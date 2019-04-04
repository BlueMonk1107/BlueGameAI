namespace BlueGOAP
{
    public interface IAction<TAction>
    {
        /// <summary>
        /// 当前动作的ID
        /// </summary>
        int ID { get; }
        /// <summary>
        /// 动作花费 默认为1
        /// </summary>
        int Cost { get; }
        /// <summary>
        /// 动作执行的优先级 默认为0
        /// </summary>
        int Precedence { get; }
        /// <summary>
        /// 获取当前动作的先决条件
        /// </summary>
        /// <returns></returns>
        IState GetPreconditions();
        /// <summary>
        /// 获取当前动作执行后对状态的影响
        /// </summary>
        /// <returns></returns>
        IState GetEffects();
        /// <summary>
        /// 验证先决条件
        /// </summary>
        /// <returns></returns>
        bool VerifyPreconditions();
        /// <summary>
        /// 添加动作完成回调
        /// </summary>
        /// <param name="onFinishAction"></param>
        void AddFinishAction(System.Action onFinishAction);
    }
}