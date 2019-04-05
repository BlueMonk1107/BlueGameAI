
using System;

namespace BlueGOAP
{
    /// <summary>
    /// ͼ�ı�
    /// </summary>
    public class Edge
    {
        //ͼ����������
        public Vertex StartVex { get; private set; }
        public Vertex EndVex { get; private set; }
        // �ߵ�Ȩ��
        public float Weight { get; set; }

        public Edge(Vertex startVex, Vertex endVex, float weight)
        {
            StartVex = startVex;
            EndVex = endVex;
            Weight = weight;
        }

        public Vertex GetAnotherVertex(int id)
        {
            if (StartVex.IsThisVertex(id))
                return EndVex;
            if (EndVex.IsThisVertex(id))
                return StartVex;
            return null;
        }

        public int CompareTo(Edge e)
        {
            // ����Ȩ�رȽ�
            if (Weight > e.Weight) return 1;
            else if (Weight < e.Weight) return -1;
            return 0;
        }
        /// <summary>
        /// ��ȡ�����
        /// </summary>
        public Edge GetReverseEdge()
        {
            return new Edge(EndVex, StartVex,Weight);
        }

        public override string ToString()
        {
            return StartVex + " to " + EndVex + ", _vexBeight: " + Weight;
        }
    }
}
