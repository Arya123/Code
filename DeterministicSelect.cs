using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    class DeterministicSelect
    {

        public static void Main(string[] args)
        {
            int[] arr = new int[] {6,5,4,3,2,1}; // {0,0,0,1,1,1}
            Console.WriteLine(KthElemSelect(arr,0,arr.Length-1,2));
        }

        public static int KthElemSelect(int[] arr, int i, int j, int k)
        {
            if (i == j)
            {
                if (i == k) return arr[i];
                else return -1;
            }
            int median = MedianOfMedians(arr, i, j);
            int med = IndexOf(arr, i ,j, median);
            
            Partition(arr, i, j, med);
            med = IndexOf(arr, i, j, median);
            
            if (med == k) return arr[med];
            else if (med < k && j - med  >= 1) return KthElemSelect(arr, med + 1, j, k);
            else if (med - i >= 1) return KthElemSelect(arr, i, med - 1, k);
            return -1;
        }

        public static int MedianOfMedians(int[] arr, int i, int j)
        {
            if (j - i <= 5)
            {
                int[] narr = new int[j - i+1];
                Array.Copy(arr, i, narr, 0, j - i+1);
                Array.Sort(narr);
                return narr[narr.Length / 2];
            }
            else
            {
                int[] marr = new int[(j - i) / 5 + (j - i % 5 == 0 ? 0 : 1)];
                for (int x = 0; x < marr.Length; x++)
                {
                    int last = x*5 + 4 > j ? j : x*5 + 4;
                    marr[x] = MedianOfMedians(arr, x * 5,last);
                }
                return MedianOfMedians(marr, 0, marr.Length-1);
            }
        }

        public static int IndexOf(int[] arr, int i, int j, int k)
        {
            for (int x = i; x <=j; x++)
            {
                if (arr[x] == k) return x;
            }
            return -1;
        }

        public static void Partition(int[] arr, int i, int j, int pivot)
        {
            if (j == i) return;
            int temp = arr[pivot];
            arr[pivot] = arr[i];
            arr[i] = temp;
            int x = i + 1, y = i + 1;

            for (; y <= j; y++)
            {
                if (arr[y] < arr[i])
                {
                    temp = arr[y];
                    arr[y] = arr[x];
                    arr[x] = temp;
                    x++;
                }
            }

            temp = arr[x - 1];
            arr[x - 1] = arr[i];
            arr[i] = temp;
        }
    }
}
