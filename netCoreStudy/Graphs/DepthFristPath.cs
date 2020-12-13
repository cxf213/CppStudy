using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreStudy.Graphs
{
    class DepthFristPath
    {
        private readonly bool[] marked;
        public int[] edgeTo;
        public int s;
        private int count;

        public DepthFristPath(Graph G, int s)
        {
            marked = new bool[G.v()];
            edgeTo = new int[G.v()];
            this.s = s;
            Dfs(G, s);
        }
        private void Dfs(Graph G, int v)
        {
            marked[v] = true;
            count++;
            for (int i = 0; i < G.adj(v).Count; i++)
            {
                if (!marked[G.adj(v)[i]])
                {
                    Dfs(G, G.adj(v)[i]);
                    edgeTo[G.adj(v)[i]] = v;
                }
            }
        }
        public Stack<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            for (int x = v; x != s; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(s);
            return path;
        }
        public bool HasPathTo(int v) => marked[v];
        public int Count() => count;
    }
}
