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
            Stopwatch sw = new Stopwatch();
            sw.Start();


            Compar<int>.Max(12,65);
            datas();


            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine();
            Console.WriteLine("Use Time: {0} ms", ts.TotalMilliseconds);
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
    }

    internal class Compar<T> where T : IComparable
    {
        public static T Max(T a, T b) => a.CompareTo(b) > 0 ? a : b;
    }


}
