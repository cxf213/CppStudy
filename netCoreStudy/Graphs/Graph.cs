using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace netCoreStudy.Graphs
{
    class Graph
    {
        private readonly int V = 0;
        private int E = 0;
        private readonly List<int>[] Adj;
        public int v() => V;
        public int e() => E;
        public List<int> adj(int v) => Adj[v];

        /// <summary>
        /// 初始化一张无向图
        /// </summary>
        /// <param name="filename">首行为节点数,次行为边数,剩余格式:节点v 节点w</param>
        public Graph(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line; bool isV = true, isE = true;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (isE && isV)
                        {
                            V = Convert.ToInt32(line);
                            isV = false;
                            Adj = new List<int>[V];
                            for (int i = 0; i < V; i++)  //初始化每个节点
                            {
                                Adj[i] = new List<int>();
                            }
                        }
                        else if (isE) isE = false;
                        else
                        {
                            string[] edges = line.Split(" ", StringSplitOptions.None);
                            AddEdge(Convert.ToInt32(edges[0]), Convert.ToInt32(edges[1]));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(e.Message);
            }
        }


        void AddEdge(int v, int w)
        {
            if (v > V || w > V) return;
            Adj[v].Add(w);
            Adj[w].Add(v);
            E++;
        }

        public override string ToString()
        {
            string s = V + " Vertices," + E + " Edges.\n";
            for (int i = 0; i < V; i++)
            {
                s += i + ": ";
                for (int j = 0; j < Adj[i].Count; j++)
                {
                    s += Adj[i][j] + " ";
                }
                s += "\n";
            }
            return s;
        }

    }
}
