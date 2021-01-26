using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace netCoreStudy.Feature
{
    class Asyncs
    {
        public static async void main()
        {
            Task<int> toast = FryToast();
            Task<int> egg = FryEggs();
            Task<int> Bacon = FryBacon();
            List<Task<int>> Jobs = new List<Task<int>> { toast, egg, Bacon };
            Console.ReadLine();
            while (Jobs.Count > 0)
            {
                Task<int> FinishedTask = await Task.WhenAny(Jobs);
                int k = FinishedTask.Result;
                Console.WriteLine("第{0}项任务完成了!",k);
                Jobs.Remove(FinishedTask);
            }
        }

        private static async Task<int> FryToast()
        {
            Console.WriteLine("Toast is Preparing!");
            await Task.Delay(5000);
            Console.WriteLine("Toast is Ready!");
            return 0;
        }
        private static async Task<int> FryEggs()
        {
            Console.WriteLine("Egg is Preparing!");
            await Task.Delay(3000);
            Console.WriteLine("Egg is Ready!");
            return 1;
        }
        private static async Task<int> FryBacon()
        {
            Console.WriteLine("Bacon is Preparing!");
            await Task.Delay(10000);
            Console.WriteLine("Bacon is Ready!");
            return 2;
        }
    }
}
