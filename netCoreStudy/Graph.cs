using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace netCoreStudy
{
    class Graph<T>
    {
        private int V = 0;
        private int E = 0;
        private List<int>[] Adj;
        public int v() => V;
        public int e() => E;
        List<int> adj(int v) => Adj[v];


        public Graph(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;bool isV=true;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if(!line.Contains(" ")&&isV)
                        {
                            V = Convert.ToInt32(line);
                            isV = false;
                        }
                        else if(!line.Contains(" "))
                        {
                            E = Convert.ToInt32(line);
                        }
                        else
                        {
                            string[] edges = line.Split(" ", StringSplitOptions.None);
                            addEdge(Convert.ToInt32(edges[0]), Convert.ToInt32(edges[1]));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        void addEdge(int v,int w)
        {

        }

        
    }
}
