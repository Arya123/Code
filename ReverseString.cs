using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    class ReverseString
    {

        public static char sepToAdd = ' ';
        public static char[] seps = { ' ', '\t', '\n' };
        static HashSet<char> seph;

        public static void Main(String[] args)
        {
            ReverseString rs = new ReverseString(seps);
            Console.WriteLine("ans:" + rs.ReverseTokensByHand("   Interviewer    is awesome!    ") + "-->");
        }

        ReverseString(char[] seps)
        {
            seph = new HashSet<char>();
            foreach (char sep in seps)
            {
                seph.Add(sep);
            }
        }

        public string Reverse(string str)
        {
            StringBuilder sb = new StringBuilder();
            bool spacef = false;
            bool isbegorend = true;
            for(int i=str.Length-1;i>=0;i--)
            {
                if (IsSeparator(str[i]))
                {
                   spacef = true;
                }
                else
                {
                    if (spacef)
                    {
                        if (isbegorend) isbegorend = false;
                        else sb.Append(sepToAdd);
                        spacef = false;
                    }
                    sb.Append(str[i]);
                }

            }
            return sb.ToString();
        }   
    

        public bool IsSeparator(char c)
        {
            return seph.Contains(c);
        }

        public string ReverseTokensOrderByFunc(string str)
        {
            string[] tokens = str.Split(seps, StringSplitOptions.RemoveEmptyEntries);
            return String.Join(sepToAdd+"", tokens.Reverse());
        }

        public string ReverseTokensByHand(string str)
        {
            Stack<char> st = new Stack<char>();
            foreach (char c in str) st.Push(c);

            bool sepf = false;
            bool isBegOrEnd = true;
            StringBuilder s = new StringBuilder();
            Stack<char> tmp = new Stack<char>();
            while (st.Count != 0)
            {
                char p = st.Pop();
                if (IsSeparator(p)) sepf = true;
                else
                {
                    if (sepf)
                    {
                        while (tmp.Count != 0) s.Append(tmp.Pop());
                        sepf = false;
                        if (!isBegOrEnd)
                        {
                            s.Append(sepToAdd);
                        }
                        else isBegOrEnd = false;
                    }
                   tmp.Push(p);
                }
            }
            if (sepf)
            {
                if (!isBegOrEnd)
                {
                    s.Append(sepToAdd);
                }
                while (tmp.Count != 0) s.Append(tmp.Pop());
            }
            return s.ToString();
        }
    }
}
