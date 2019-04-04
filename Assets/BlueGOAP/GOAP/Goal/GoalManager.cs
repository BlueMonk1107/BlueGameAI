
using System.Collections.Generic;

namespace BlueGOAP
{
    //����Ǵ���0�ģ���һ������
    //�����������ɴ�С���е�
    public class ComparerGoal : IComparer<IGoal>
    {
        public int Compare(IGoal x, IGoal y)
        {
            return x.CompareTo(y);
        }
    }
    public abstract class GoalManager<TAction, TGoal> : IGoalManager<TGoal>
    {
        private Dictionary<TGoal, IGoal> _goalsDic;
        private IAgent<TAction, TGoal> _agent;
        public IGoal CurrentGoal { get; private set; }
        private List<IGoal> _activeGoals;
        private IGoal _currentGoal;

        public GoalManager(IAgent<TAction, TGoal> agent)
        {
            _currentGoal = null;
            _goalsDic = new Dictionary<TGoal, IGoal>();
            _activeGoals = new List<IGoal>();
            InitGoals();
        }

        /// <summary>
        /// ��ʼ����ǰ�����Ŀ��
        /// </summary>
        protected abstract void InitGoals();

        public void AddGoal(TGoal goalLabel)
        {
            var goal = _agent.Maps.GetGoal(goalLabel);
            if (goal != null)
            {
                _goalsDic.Add(goalLabel, goal);
                goal.AddGoalActivateListener((activeGoal) => _activeGoals.Add(activeGoal));
                goal.AddGoalInactivateListener((activeGoal) => _activeGoals.Remove(activeGoal));
            }
        }

        private void SortGoalList()
        {
            _activeGoals.Sort(new ComparerGoal());
        }

        public void RemoveGoal(TGoal goalLabel)
        {
            _goalsDic.Remove(goalLabel);
        }

        public IGoal GetGoal(TGoal goalLabel)
        {
            if (_goalsDic.ContainsKey(goalLabel))
            {
                return _goalsDic[goalLabel];
            }

            DebugMsg.LogError("Not add goal name:" + goalLabel);
            return null;
        }

        public IGoal FindGoal()
        {
            //�������ȼ������Ǹ�
            SortGoalList();
            if (_activeGoals.Count > 0)
            {
                return _activeGoals[0];
            }
            else
            {
                return null;
            }
        }

        public void UpdateData()
        {
            UpdateGoals();
            UpdateCurrentGoal();
        }
        //��������Goal����Ϣ
        private void UpdateGoals()
        {
            foreach (KeyValuePair<TGoal, IGoal> goal in _goalsDic)
            {
                goal.Value.Update();
            }
        }
        //����_currentGoal����
        private void UpdateCurrentGoal()
        {
            if (_currentGoal == null)
            {
                _currentGoal = FindGoal();
            }
        }
    }
}
