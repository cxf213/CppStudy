using System;
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

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine("Use Time: {0} ms", ts.TotalMilliseconds);
        }
    }

    internal class Compar<T> where T : IComparable
    {
        static public T Max(T a, T b) => a.CompareTo(b) > 0 ? a : b;
    }


}
