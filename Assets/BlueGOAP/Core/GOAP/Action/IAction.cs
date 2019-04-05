namespace BlueGOAP
{
    public interface IAction<TAction>
    {
        /// <summary>
        /// ��ǰ�����ı�ǩ
        /// </summary>
        TAction Label { get; }
        /// <summary>
        /// �������� Ĭ��Ϊ1
        /// </summary>
        int Cost { get; }
        /// <summary>
        /// ����ִ�е����ȼ� Ĭ��Ϊ0
        /// </summary>
        int Precedence { get; }
        /// <summary>
        /// ִ�ж������Ⱦ�����
        /// </summary>
        IState Preconditions { get; }

        /// <summary>
        /// ����ִ�к��״̬
        /// </summary>
        IState Effects { get; }
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