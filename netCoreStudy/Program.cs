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


            Feature.SimpleEvent.MainClass.Mains();
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
