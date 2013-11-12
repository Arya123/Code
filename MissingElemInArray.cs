using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    class MissingElemInArray
    {

        public static void Main(string[] args)
        {
            int[] a = new int[] {1,1,2,3,4,5,78,0};
            int[] b = new int[] { 1, 2, 4, 5,1,78,0 };
            Console.WriteLine(MissingElemInArray.FindMissingElemBySum(a,b)+"\t"+MissingElemInArray.FindMissingElemByXor(a,b));
        }

        public static int FindMissingElemBySum(int[] A, int[] B)
        {
            int sum = 0;
            for (int i = 0; i < A.Length; i++) sum += A[i];
            for (int i = 0; i < B.Length; i++) sum -= B[i];
            return sum;
        }

        public static int FindMissingElemByXor(int[] A, int[] B)
        {
            int xorval = 0;
            for (int i = 0; i < A.Length; i++) xorval ^= A[i];
            for (int i = 0; i < B.Length; i++) xorval ^= B[i];
            return xorval;
        }
    }
}
