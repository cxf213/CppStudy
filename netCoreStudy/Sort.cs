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
        static private void SectorInsertSort(T[] arr,int low,int high)
        {
            int minOfIndex = low;
            for (int i = low; i < high; i++)
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
        static public void QuickSort(T[] arr) { QuickSort(arr, 0, arr.Length - 1); }
        static private void QuickSort(T[] arr, int low, int hi)
        {
            
            if (low >= hi - 8)
            {
                SectorInsertSort(arr, low, hi);
                return;
            }

            int lt = low + 1, ht = hi, i = low + 1;
            T v = arr[low];
            while (i <= ht)
            {
                int comp = arr[i].CompareTo(v);
                if (comp > 0) Swap(ref arr[ht--], ref arr[i]);
                else if (comp < 0) Swap(ref arr[lt++], ref arr[i++]);
                else i++;
            }
            QuickSort(arr, 0, lt - 1);
            QuickSort(arr, ht + 1, hi);
        }
    }
}
