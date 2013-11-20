using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    class MatrixRegionSum
    {

        public static void Main(string[] args)
        {
            int[][] arr = { new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 } };
            MatrixRegionSum msr = new MatrixRegionSum();
            Console.WriteLine(msr.GetRegionSum(arr, 1, 1, 3, 3));
            Console.WriteLine(msr.GetRegionSum(arr, 1, 1, 2, 2));
            Console.WriteLine(msr.GetRegionSum(arr, 1, 1, 1, 1));
            Console.WriteLine(msr.GetRegionSum(arr, 2, 2, 3, 3));
            Console.WriteLine(msr.GetRegionSum(arr, 2, 3, 3, 3));
        }

        private int[][] table;

        public void GetXYRegionSum(int[][] arr)
        {
            table = new int[arr.Length][];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new int[arr[0].Length];
            }

            for (int i = table.Length - 1; i >= 0; i--)
            {
                for (int j = table[0].Length - 1; j >= 0; j--)
                {
                    int r = 0, b = 0, c = 0;
                    if (i + 1 < table.Length) r = table[i + 1][j];
                    if (j + 1 < table[0].Length) b = table[i][j + 1];
                    if (i + 1 < table.Length && j + 1 < table[0].Length) c = table[i + 1][j + 1];
                    table[i][j] = arr[i][j] + r + b - c;
                }
            }

        }

        public int GetRegionSum(int[][] arr, int x1, int y1, int x2, int y2)
        {
            if(table == null) GetXYRegionSum(arr);
            int m =0, r = 0, b = 0, c = 0;
            if(x1 < arr.Length && y1 < arr[0].Length) m = table[x1][y1];
            if(x1 < arr.Length && y2+1 < arr[0].Length) r = table[x1][y2+1];
            if(x2+1 < arr.Length && y1 < arr[0].Length) b = table[x2+1][y1];
            if(x2+1 < arr.Length && y2+1 < arr[0].Length) c = table[x2+1][y2+1];

            return m - r - b + c;
        }
    }
}
