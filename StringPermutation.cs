using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    class StringPermutation
    {
        public static void Main(string[] args)
        {
            string str = "abc";
            foreach (string s in GetAllPermutations(str,0))
            {
                Console.WriteLine(s);
            }
        }

        //If multiset, then generates duplicate permutations
        public static List<string> GetAllPermutations(string str, int index)
        {
            if (index == str.Length - 1)
            {
                List<string> s = new List<string>();
                s.Add(str[index] + "");
                return s;
            }
            List<string> perms = GetAllPermutations(str, index + 1);
            List<string> nperms = new List<string>();

            for (int i = 0; i < str.Length - index; i++)
            {
                foreach (string s in perms)
                {
                    nperms.Add(s.Insert(i, str[index]+""));
                }
            }
            return nperms;
        }
    
    }
}
