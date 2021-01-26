using netCoreStudy.Graphs;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace netCoreStudy
{
    class Program
    {
        
        static void Main(string[] args)
        {
            double num = 12.3456;
            Console.WriteLine($"the num is |{num:0.00}|");

            Feature.Asyncs.main();
            Console.ReadLine();
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
}
