
using System;
using System.Collections;
using System.Collections.Generic;

namespace BlueGOAP
{
    public class State : IState
    {
        private Dictionary<string, bool> _dataTable;
        private Action _onChange;

        public State()
        {
            _dataTable = new Dictionary<string, bool>();
        }

        public void SetState(string key, bool value)
        {
            if (_dataTable.ContainsKey(key) && _dataTable[key] != value)
            {
                if (_onChange != null )
                    _onChange();
            }
            else if(!_dataTable.ContainsKey(key))
            {
                if (_onChange != null)
                    _onChange();
            }

            _dataTable[key] = value;
        }

        public void AddStateChangeListener(Action onChange)
        {
            _onChange = onChange;
        }

        public IState GetSameData(IState goalState)
        {
            IState data = new State();
            foreach (var entry in _dataTable)
            {
                if (goalState.ContainKey(entry.Key))
                {
                    data.SetState(entry.Key, _dataTable[entry.Key]);
                }
            }

            return data;
        }

        public bool GetValue(string key)
        {
            if (key == null)
            {
                DebugMsg.Log("state key can not be null!");
            }
            return _dataTable[key];
        }

        public bool ContainState(IState otherState)
        {
            foreach (var key in otherState.GetKeys())
            {
                if (!ContainKey(key) || _dataTable[key] != otherState.GetValue(key))
                {
                    return false;
                }
            }

            return true;
        }

        public ICollection<string> GetValueDifferences(IState otherState)
        {
            List<string> keys = new List<string>();
            foreach (var key in otherState.GetKeys())
            {
                if (otherState.GetValue(key) != _dataTable[key])
                {
                    keys.Add(key);
                }
            }

            return keys;
        }

        public void SetKeys(IState agentState, IState otherState)
        {
            foreach (var key in otherState.GetKeys())
            {
                SetState(key, agentState.GetValue(key));
            }
        }

        public void SetData(IState otherState)
        {
            foreach (var key in otherState.GetKeys())
            {
                SetState(key, otherState.GetValue(key));
            }
        }

        public bool ContainKey(string key)
        {
            return _dataTable.ContainsKey(key);
        }

        public ICollection<string> GetKeys()
        {
            return _dataTable.Keys;
        }

        public void Clear()
        {
            _dataTable.Clear();
        }
    }

    public class State<TKey> : State
    {
        public State() : base()
        {

        }

        public void SetState(TKey key, bool value)
        {
            base.SetState(key.ToString(), value);
        }

        public bool GetValue(TKey key)
        {
            return base.GetValue(key.ToString());
        }

        public bool ContainKey(TKey key)
        {
            return base.ContainKey(key.ToString());
        }
    }
}
