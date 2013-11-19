using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    class Sqrt
    {
        // Find integer square root without using sqrt function.
        public static void Main(string[] args)
        {
            Console.WriteLine(GetSqrt(612,0.00001));
            for (int i = 0; i < 70; i++)
            {
                Console.WriteLine(i + ": " + GetSqrtFloorBrute(i) + "\t" + GetSqrtByBS(0,i,i) + "\t" + GetSqrt(i, 0.00000001));
            }
        }


        

        // Method 1: Brute force: takes O(n) time. 

        public static int GetSqrtFloorBrute(int N)
        {
            if (N < 1) return 0;
            for (int i = 1; i <= N / 2 + 1; i++)
            {
                if (i * i < N) continue;
                else if (i * i == N) return i;
                {
                    return i - 1;
                }
            }
            return -1;
        }

        //Method 2: Use log function: takes O(log N) time, using MSB set function. 

        public static double GetSqrtFloorLog(int N)
        {
            return Math.Pow(2, (0.5 * MostSignificantSetbit(N)));
        }


        public static int MostSignificantSetbit(int N)
        {
            int c = 0;
            while ((N >>= 1) != 0)
            {
                c++;
            }
            return c;
        }

        //Method 3: Use binary search
        public static int GetSqrtByBS(int low, int high, int N)
        {

            int mid = low + (high - low) / 2;
            if (mid * mid <= N && (mid + 1) * (mid + 1) > N)
            {
                return mid;
            }
            if (mid * mid > N && mid - 1 - low >= 0) return GetSqrtByBS(low, mid - 1, N);
            else if (high - mid - 1 >= 0) return GetSqrtByBS(mid + 1, high, N);
            else return -1;

        }

        //Method 4: Use Newton-Rhapson method. 
        public static double GetSqrt(int N, double epoch)
        {
            if (N == 0) return 0;
            if (N <=3) return 1;
            double guess = 10;
            
            double fx = guess*guess - N;
            double fdx = 2 * guess;
            while (true)
            {
                double ng = guess - fx / fdx;
                if (Math.Abs(ng - guess) < epoch) 
                    return ng;
                else
                {
                    guess = ng;
                    fx = guess * guess - N;
                    fdx = 2 * guess;
                }
            }


        } 
    }
}
