namespace BlueGOAP
{
    public interface IAction<TAction>
    {
        /// <summary>
        /// ��ǰ������ID
        /// </summary>
        int ID { get; }
        /// <summary>
        /// �������� Ĭ��Ϊ1
        /// </summary>
        int Cost { get; }
        /// <summary>
        /// ����ִ�е����ȼ� Ĭ��Ϊ0
        /// </summary>
        int Precedence { get; }
        /// <summary>
        /// ��ȡ��ǰ�������Ⱦ�����
        /// </summary>
        /// <returns></returns>
        IState GetPreconditions();
        /// <summary>
        /// ��ȡ��ǰ����ִ�к��״̬��Ӱ��
        /// </summary>
        /// <returns></returns>
        IState GetEffects();
        /// <summary>
        /// ��֤�Ⱦ�����
        /// </summary>
        /// <returns></returns>
        bool VerifyPreconditions();
        /// <summary>
        /// ��Ӷ�����ɻص�
        /// </summary>
        /// <param name="onFinishAction"></param>
        void AddFinishAction(System.Action onFinishAction);
    }
}