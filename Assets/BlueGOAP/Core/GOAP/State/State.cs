
using System;
using System.Collections;
using System.Collections.Generic;

namespace BlueGOAP
{
    public class State : IState
    {
        private Hashtable _dataTable;
        private Action _onChange;

        public State()
        {
            _dataTable = Hashtable.Synchronized(new Hashtable());
        }

        public void SetState(object key, object value)
        {
            if (key == null)
            {
                DebugMsg.Log("state key can not be null!");
            }
            else
            {
                if (_dataTable.Contains(key))
                {
                    _dataTable[key] = value;
                }
                else
                {
                    _dataTable.Add(key,value);
                }

                _onChange();
            }
        }

        public void AddStateChangeListener(Action onChange)
        {
            _onChange += onChange;
        }

        public IState GetSameData(IState goalState)
        {
            IState data = new State();
            foreach (DictionaryEntry entry in _dataTable)
            {
                if (goalState.ContainKey(entry.Key))
                {
                    data.SetState(entry.Key, _dataTable[entry.Key]);
                }
            }

            return data;
        }

        public object GetValue(object key)
        {
            if (key == null)
            {
                DebugMsg.Log("state key can not be null!");
            }
            return _dataTable[key];
        }

        public bool ContainState(IState otherState)
        {
            foreach (object key in otherState.GetKeys())
            {
                if ( !ContainKey(key) || _dataTable[key] != otherState.GetValue(key))
                {
                    return false;
                }
            }

            return true;
        }

        public List<object> GetValueDifferences(IState otherState)
        {
            List<object> keys = new List<object>();
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
            foreach (object key in otherState.GetKeys())
            {
                if (!_dataTable.ContainsKey(key))
                {
                    _dataTable.Add(key, agentState.GetValue(key));
                }
            }

            _onChange();
        }

        public void SetData(IState otherState)
        {
            foreach (object key in otherState.GetKeys())
            {
                _dataTable[key] = otherState.GetValue(key);
            }
            _onChange();
        }

        public bool ContainKey(object key)
        {
            return _dataTable.Contains(key);
        }

        public ICollection GetKeys()
        {
            return _dataTable.Keys;
        }

        public void Clear()
        {
            _dataTable.Clear();
        }
    }
}
