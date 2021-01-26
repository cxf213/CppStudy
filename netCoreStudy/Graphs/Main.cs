using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using netCoreStudy.Graphs;

namespace netCoreStudy.Graphs
{
    class Main
    {
        static void main()
        {
            List<double> list = new List<double>(new double[10000]);
            double[] list2 = new double[10000];
            Stopwatch sw = new Stopwatch(); //
            sw.Start();                     //计时器开始

            Graph G1 = new Graph(@"D:\Codes\CppStudy\netCoreStudy\Graphs\tinyG.txt");
            DepthFristPath dfs1 = new DepthFristPath(G1, 0);
            BreadthFirstPath bfs1 = new BreadthFirstPath(G1, 0);
            Stack<int> ans = bfs1.PathTo(3);


            sw.Stop();                      //计时器结束
            TimeSpan ts = sw.Elapsed;
            //foreach (var i in dfs1.PathTo(3)) Console.Write(i+"->");
            Console.WriteLine();
            //foreach (var i in bfs1.PathTo(3)) Console.Write(i + "->");
            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("Use Time: {0} ms", ts.TotalMilliseconds);
        }
    }
}
