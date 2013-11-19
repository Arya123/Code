using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    class ArrayPairSum
    {
        public static void Main(string[] args)
        {
            int[] arr = {1, 3, 4, 4, 6};
            Console.WriteLine(ArrayPairPresentUsingSort(arr,8));
            Console.WriteLine(ArrayPairSumUsingSet(arr, 8));
        }

        public static bool ArrayPairPresentUsingSort(int[] arr, int k)
        {
            Array.Sort(arr);
            int i = 0, j = arr.Length - 1, sum = 0;
            while (i < j)
            {
                sum = arr[i] + arr[j];
                if (sum == k) return true;
                else if (sum < k) i++;
                else j--;
            }
            return false;
        }

        public static bool ArrayPairSumUsingSet(int[] arr, int k)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (set.Contains(arr[i]))
                {
                    if (2 * arr[i] == k) return true;
                }
                else if (set.Contains(k - arr[i]))
                {
                    return true;
                }
                else set.Add(arr[i]);
            }
            return false;
        }

    }
}
