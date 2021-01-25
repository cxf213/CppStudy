﻿using netCoreStudy.Graphs;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace netCoreStudy
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<double> list = new List<double>(new double[10000]);
            double[] list2 = new double[10000];
            Stopwatch sw = new Stopwatch(); //
            sw.Start();                     //计时器开始

            Graph G1 = new Graph(@"D:\Codes\CppStudy\netCoreStudy\Graphs\tinyG.txt");
            DepthFristPath dfs1 = new DepthFristPath(G1, 0);
            BreadthFirstPath bfs1 = new BreadthFirstPath(G1, 0);
            Stack<int> ans = bfs1.PathTo(3);
            foreach(var i in ans)
            {
                Console.Write(i+"->");
            }
            Console.WriteLine();
            ans = dfs1.PathTo(3);
            foreach (var i in ans)
            {
                Console.Write(i + "->");
            }

            sw.Stop();                      //计时器结束
            TimeSpan ts = sw.Elapsed;
            //foreach (var i in dfs1.PathTo(3)) Console.Write(i+"->");
            Console.WriteLine();
            //foreach (var i in bfs1.PathTo(3)) Console.Write(i + "->");
            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("Use Time: {0} ms", ts.TotalMilliseconds);
            Console.ReadLine();
        }
        static void TestExample()
        {
            int[] arr = GetRandArray(100000);
            Sort<int>.InsertSort(arr); //35708.5ms for 10kdata
            Sort<int>.QuickSort(arr);    //38.1ms for 10kdata
        }
        static int[] GetRandArray(int len)
        {
            Random rd = new Random(2333);
            int[] arr = new int[len];
            for (int i = 0; i < len; i++)
            {

                arr[i] = rd.Next(1000,9999);
            }
            return arr;
        }
    }

    internal class Compar<T> where T : IComparable
    {
        public static T Max(T a, T b) => a.CompareTo(b) > 0 ? a : b;
    }

}
