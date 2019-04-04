using UnityEngine;

namespace BlueToolkit
{
    public static class PathManager
    {
        /// <summary>
        /// ����·��
        /// </summary>
        public static readonly string CachePath = "Assets/ToolKit/Cache/";
        /// <summary>
        /// ����������·��
        /// </summary>
        public static readonly string FontDataPath = CachePath + "FontData.asset";
        /// <summary>
        /// Entitas��ܽű�һ�����ɹ��߻���·��
        /// </summary>
        public static readonly string EntitasDataPath = CachePath + "EntitasData.asset";
        /// <summary>
        /// StrangeIOC��ܽű�һ�����ɹ��߻���·��
        /// </summary>
        public static readonly string StrangeIOCDataPath = CachePath + "StrangeIOC.asset";

        /// <summary>
        /// �Զ���������ռ�������·��
        /// </summary>
        public static readonly string NameSpaceDataPath = CachePath + "Namespace.asset";
    }
}
