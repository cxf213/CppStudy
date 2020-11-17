using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreStudy
{
    static class Sort<T> where T:IComparable
    {

        static private void Swap(ref T a,ref T b)
        {
            T temp = a;a = b;b = temp;
        }
        static public void InsertSort( T[] arr)
        {
            int minOfIndex = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                minOfIndex = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[minOfIndex]) == -1)
                    {
                        minOfIndex = j;
                    }
                }
                Swap(ref arr[i], ref arr[minOfIndex]);
            }
        }

    }
}
