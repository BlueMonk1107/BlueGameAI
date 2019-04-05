using System.Collections.Generic;

namespace BlueGOAP
{
    public interface IFsmState<TLabel>
    {
        /// <summary>
        /// 动作状态标签
        /// </summary>
        TLabel Label { get; }

        /// <summary>
        /// 进入动作
        /// </summary>
        void Enter();
        /// <summary>
        /// 更新动作
        /// </summary>
        void Execute();
        /// <summary>
        /// 退出动作
        /// </summary>
        void Exit();
    }

    public interface IFSM<TLabel>
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        TLabel CurrentState { get; }
        /// <summary>
        /// 前一个状态
        /// </summary>
        TLabel BeforeTheState { get; }
        /// <summary>
        /// 添加需要管理的状态
        /// </summary>
        /// <param name="label"></param>
        /// <param name="state"></param>
        void AddState(TLabel label, IFsmState<TLabel> state);
        /// <summary>
        /// 改变状态
        /// </summary>
        /// <param name="newState"></param>
        void ChangeState(TLabel newState);
        /// <summary>
        /// 帧函数
        /// </summary>
        void FrameFun();
    }

    /// <summary>
    /// 状态机
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

        //注册一个新状态到字典里
        public void AddState(TLabel label, IFsmState<TLabel> state)
        {
            _stateDic[label] = state;
        }

        //切换状态
        public void ChangeState(TLabel newState)
        {
            _previousState = _currentState;
            _currentState = _stateDic[newState];

            if(_previousState != null)
                _previousState.Exit();

            if(_currentState != null)
                _currentState.Enter();
        }
        
        //执行状态，每帧执行
        public void FrameFun()
        {
            if (_currentState != null)
            {
                _currentState.Execute();
            }
        }
    }
}
