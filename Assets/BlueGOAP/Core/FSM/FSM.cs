using System.Collections.Generic;

namespace BlueGOAP
{
    public interface IFsmState<TLabel>
    {
        /// <summary>
        /// ����״̬��ǩ
        /// </summary>
        TLabel Label { get; }

        /// <summary>
        /// ���붯��
        /// </summary>
        void Enter();
        /// <summary>
        /// ���¶���
        /// </summary>
        void Execute();
        /// <summary>
        /// �˳�����
        /// </summary>
        void Exit();
    }

    public interface IFSM<TLabel>
    {
        /// <summary>
        /// ��ǰ״̬
        /// </summary>
        TLabel CurrentState { get; }
        /// <summary>
        /// ǰһ��״̬
        /// </summary>
        TLabel BeforeTheState { get; }
        /// <summary>
        /// �����Ҫ�����״̬
        /// </summary>
        /// <param name="label"></param>
        /// <param name="state"></param>
        void AddState(TLabel label, IFsmState<TLabel> state);
        /// <summary>
        /// �ı�״̬
        /// </summary>
        /// <param name="newState"></param>
        void ChangeState(TLabel newState);
        /// <summary>
        /// ֡����
        /// </summary>
        void FrameFun();
    }

    /// <summary>
    /// ״̬��
    /// </summary>
    /// <typeparam name="TLabel"></typeparam>
    public class FSM<TLabel> : IFSM<TLabel>
    {
        private readonly Dictionary<TLabel, IFsmState<TLabel>> _stateDic;
        private IFsmState<TLabel> _currentState;
        private IFsmState<TLabel> _previousState;


        public TLabel CurrentState
        {
            get { return _currentState.Label; }
        }

        public TLabel BeforeTheState
        {
            get { return _previousState.Label; }
        }


        public FSM()
        {
            _stateDic = new Dictionary<TLabel, IFsmState<TLabel>>();
        }

        //ע��һ����״̬���ֵ���
        public void AddState(TLabel label, IFsmState<TLabel> state)
        {
            _stateDic[label] = state;
        }

        //�л�״̬
        public void ChangeState(TLabel newState)
        {
            _previousState = _currentState;
            _currentState = _stateDic[newState];

            if(_previousState != null)
                _previousState.Exit();

            if(_currentState != null)
                _currentState.Enter();
        }
        
        //ִ��״̬��ÿִ֡��
        public void FrameFun()
        {
            if (_currentState != null)
            {
                _currentState.Execute();
            }
        }
    }
}
