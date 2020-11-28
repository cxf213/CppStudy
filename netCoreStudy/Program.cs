using netCoreStudy.Graphs;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace netCoreStudy
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch(); //
            sw.Start();                     //计时器开始

            Graph G1 = new Graph(@"D:\Codes\CppStudy\netCoreStudy\Graphs\tinyG.txt");
            DepthFristPath dfs1 = new DepthFristPath(G1, 0);





            sw.Stop();                      //计时器结束
            TimeSpan ts = sw.Elapsed;       //

            Console.WriteLine(G1.ToString());
            Console.WriteLine(dfs1.PathToString(3));

            Console.WriteLine("---------------------");
            Console.WriteLine("Use Time: {0} ms", ts.TotalMilliseconds);
            Console.ReadLine();
        }
        static void testExample()
        {
            int[] arr = GetRandArray(100000);
            Sort<int>.InsertSort(arr); //35708.5ms for 10kdata
            Sort<int>.QuickSort(arr);    //38.1ms for 10kdata
        }
        static void datas()
        {
        }
        static void printArray(int[] arr)
        {
            foreach (int i in arr) Console.WriteLine(i);
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
