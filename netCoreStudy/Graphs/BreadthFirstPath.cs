using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreStudy.Graphs
{
    class BreadthFirstPath
    {
        private bool[] marked;
        public int[] edgeTo;
        public int s;

        public BreadthFirstPath(Graph G,int s)
        {
            marked = new bool[G.v()];
            edgeTo = new int[G.v()];
            this.s = s;
            bfs(G, s);
        }
        private void bfs(Graph G,int s)
        {
            Queue<int> queue = new Queue<int>();
            marked[s] = true;
            queue.Enqueue(s);
            while (queue.Count != 0)
            {
                int v = queue.Dequeue();
                foreach(var w in G.adj(v))
                {
                    if (!marked[w])
                    {
                        edgeTo[w] = v;
                        marked[w] = true;
                        queue.Enqueue(w);
                    }
                }

            }
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
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
    }
}
