using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace netCoreStudy
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch(); //
            sw.Start();                     //计时器开始

            Graph<int> G1 = new Graph<int>(@"D:\Codes\CppStudy\netCoreStudy\tinyG.txt");


            sw.Stop();                      //计时器结束
            TimeSpan ts = sw.Elapsed;       //

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
            int i = 0;
            List<int> list1 = new List<int>() { 1,2 };
            Stack<int> stack1 = new Stack<int>();
            Queue<int> queue1 = new Queue<int>();
            HashSet<int> hash1 = new HashSet<int>();
            Dictionary<int, int> dict1 = new Dictionary<int, int>();
            _ = dict1[1];
            
            i=list1[1];
            Console.WriteLine(i);
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
