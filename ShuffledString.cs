using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    class ShuffledString
    {

        public static void Main(string[] args)
        {
            Console.WriteLine(IsShuffledStringDP("def", "abc", "abdcef"));
        }

        //Assumes distinct chars
        public static bool IsShuffledString(string a, string b, string c)
        {
            if (c.Length != a.Length + b.Length) return false;
            int ia = 0, ib = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (ia < a.Length && c[i] == a[ia]) ia++;
                else if (ib < b.Length && c[i] == b[ib]) ib++;
                else return false;
            }

            return true;

        }

        //DP solution
        public static bool IsShuffledStringDP(string a, string b, string c)
        {
            bool[][] table = new bool[a.Length + 1][];
            for (int i = 0; i < table.Length; i++)
                table[i] = new bool[b.Length + 1];

            table[a.Length][b.Length] = true;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (c[i + b.Length] == a[i]) table[i][b.Length] = table[i + 1][b.Length];
                else table[i][b.Length] = false;

            }

            for (int i = b.Length - 1; i >= 0; i--)
            {
                if (c[i + a.Length] == b[i]) table[a.Length][i] = table[a.Length][i + 1];
                else table[a.Length][i] = false;
            }

            for (int i = a.Length - 1; i >= 0; i--)
            {
                for (int j = b.Length - 1; j >= 0; j--)
                {
                    bool isa = false, isb = false;
                    if (c[i + j] == a[i]) isa = table[i + 1][j];
                    if (c[i + j] == b[j]) isb = table[i][j + 1];
                    table[i][j] = isa || isb;
                }
            }

            return table[0][0];

        }
    }
}
