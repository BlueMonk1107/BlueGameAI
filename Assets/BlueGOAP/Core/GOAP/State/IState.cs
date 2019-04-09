using System;
using System.Collections;
using System.Collections.Generic;

namespace BlueGOAP
{
    public interface IState
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetState(string key, bool value);
        /// <summary>
        /// ��������޸ļ���
        /// </summary>
        /// <param name="onChange"></param>
        void AddStateChangeListener(Action onChange);
        /// <summary>
        /// ��ȡ����Stateͬʱ�����ļ�ֵ����ǰ״̬��ֵ��Ӧ������
        /// </summary>
        IState GetSameData(IState otherState);
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool GetValue(string key);
        /// <summary>
        /// ����ǰState����otherState���еļ�ֵ�ԣ��Ҷ�Ӧֵ����ȣ�����true����֮����false
        /// </summary>
        /// <returns></returns>
        bool ContainState(IState otherState);
        /// <summary>
        /// ��ȡ������һ��״̬�Ĳ����ֵ����
        /// </summary>
        /// <param name="otherState"></param>
        /// <returns></returns>
        ICollection<string> GetValueDifferences(IState otherState);
        /// <summary>
        /// �����ṩ״̬�����м�ֵ����ɸѡ
        /// ��ǰ״̬�����ڵľ���ӽ��������������
        /// </summary>
        void SetKeys(IState agentState,IState otherState);
        /// <summary>
        /// �����ṩ״̬���������ݸ��ǵ���ǰ״̬
        /// </summary>
        void SetData(IState otherState);
        /// <summary>
        /// �ڲ������Ƿ�������ṩkey
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ContainKey(string key);
        /// <summary>
        /// ��ȡ��ǰ���м�ֵ
        /// </summary>
        /// <returns></returns>
        ICollection<string> GetKeys();
        /// <summary>
        /// �������
        /// </summary>
        void Clear();
    }
}
