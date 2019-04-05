
using System.Collections.Generic;
using UnityEngine;

namespace BlueGOAP
{
    //����Ǵ���0�ģ���һ����С
    public class ComparerWeight : IComparer<Edge>
    {
        public int Compare(Edge x, Edge y)
        {
            return x.CompareTo(y);
        }
    }
    //����ķ�㷨 MST = mini span tree
    public class MSTPrim
    {
        private bool[] _isMark; // �������Ķ���
        private List<Edge> _mstEdges; // �������ı�
        private PriorityQueue<Edge> pqueue; // ���б�

        public MSTPrim(Graph g)
        {
            _isMark = new bool[g.VexCount];
            _mstEdges = new List<Edge>();
            pqueue = new PriorityQueue<Edge>(new ComparerWeight());
            Visit(g, 0);
            while (pqueue.Count > 0)
            {
                Edge e = pqueue.Pop();
                Vertex a = e.StartVex;
                Vertex b = e.EndVex;

                if (_isMark[a.ID] && _isMark[b.ID])
                    continue; // ��Ч�ı�

                _mstEdges.Add(e);

                if (!_isMark[a.ID])
                    Visit(g, a.ID);

                if (!_isMark[b.ID])
                    Visit(g, b.ID);
            }
        }

        private void Visit(Graph g, int vexId)
        { 
            // ���ʵ�ǰ�ڵ㣬�������ı�ȫ���ӽ����ȶ�����
            _isMark[vexId] = true;
            foreach (Edge e in g.GetEdgesByVex(vexId))
            {
                if (!_isMark[e.GetAnotherVertex(vexId).ID])
                {
                    pqueue.Push(e);
                }
            }
        }

        public double Weight()
        {
            double weight = 0;
            foreach (Edge e in GetEdges())
            {
                weight += e.Weight;
            }
            return weight;
        }

        public List<Edge> GetEdges()
        {
            return _mstEdges;
        }
    }

}
