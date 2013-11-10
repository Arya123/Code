using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    class TransformWordWithDictionary
    {
        

        public static void Main(string[] args)
        {
            string[] dict = {"cat", "at", "bat", "ad", "bet", "ed", "bed"};    
            AdjGraph g = new AdjGraph(dict.Length);
            for(int i=0;i<dict.Length;i++)
            {
                List<int> edges = new List<int>();
                for(int j=0;j<dict.Length;j++)
                    {
                        if(i!=j && IsTransform(dict[i], dict[j])) edges.Add(j);
                    }
                g.AddList(i,edges);
            }

            Console.WriteLine(AdjGraph.GetShortestPathUsingBFS(g,0,6));

        }

        public static bool IsTransform(string a, string b)
        {
            int l = Math.Abs(a.Length - b.Length);
            if (l > 1) return false;
            else if (l == 1)
            {
                return a.Length > b.Length ? a.Contains(b) : b.Contains(a);
            }
            else
            {
                bool diff = false;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        if (diff) return false;
                        else diff = true;
                    }
                }
                return diff;
            }

        }
    }
}
