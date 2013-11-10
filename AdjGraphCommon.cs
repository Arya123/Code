using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Code
{
    


    class AdjGraph
    {
        private List<int>[] adjlist;
        
        public int Count
        {
            get { return adjlist.Length; }
        }

        public List<int> this[int i]
        {
            get { return adjlist[i]; }
        }

        public AdjGraph(int numnodes)
        {
            adjlist = new List<int>[numnodes];
        }

        public void AddList(int node, List<int> list)
        {
            if (adjlist[node] != null) throw new Exception("Graph already contains list for " + node);
            else adjlist[node] = list;
        }

        


        public static List<int> BreadthFirstSearch(AdjGraph graph)
        {
            List<int> res = new List<int>();
            Queue<int> q = new Queue<int>();
            if (graph.Count > 0)
            {
                q.Enqueue(0);
                bool[] visited = new bool[graph.Count];
                while (q.Count > 0)
                {
                    int node = q.Dequeue();
                    if (!visited[node])
                    {
                        visited[node] = true;
                        res.Add(node);
                        foreach (int i in graph[node])
                        {
                            if (!visited[i]) q.Enqueue(i);
                        }
                    }
                }
            }
            return res;
        }

        public static int GetShortestPathUsingBFS(AdjGraph graph, int start, int end)
        {
            List<int> res = new List<int>();
            Dictionary<int,int> level = new Dictionary<int, int>();
            Queue<int> q = new Queue<int>();
            if (graph.Count > 0)
            {
                q.Enqueue(start);
                level.Add(0,0);
                bool[] visited = new bool[graph.Count];
                while (q.Count > 0)
                {
                    int node = q.Dequeue();
                    
                    if (!visited[node])
                    {
                        visited[node] = true;
                        res.Add(node);
                        
                        foreach (int i in graph[node])
                        {
                            if (!visited[i])
                            {
                                if (i == end) return level[node]+1;
                                q.Enqueue(i);
                                if(!level.ContainsKey(i)) level.Add(i,level[node]+1);
                            }
                        }
                    }
                }
            }
            return -1;
        }

        public static void Main(string[] args)
        {
            AdjGraph g = new AdjGraph(7);
            Dictionary<int,string> words = new Dictionary<int, string>();
            words.Add(0, "cat");
            words.Add(1, "at");
            words.Add(2, "bat");
            words.Add(3, "ad");
            words.Add(4, "bet");
            words.Add(5, "ed");
            words.Add(6, "bed");
            g.AddList(0, new List<int>());
            g[0].Add(1);
            g[0].Add(2);
            g.AddList(1, new List<int>());
            g[1].Add(0);
            g[1].Add(2);
            g[1].Add(3);
            g.AddList(2, new List<int>());
            g[2].Add(0);
            g[2].Add(1);
            g[2].Add(4);
            g.AddList(3, new List<int>());
            g[3].Add(1);
            g[3].Add(5);
            g.AddList(4, new List<int>());
            g[4].Add(2);
            g[4].Add(6);
            g.AddList(5, new List<int>());
            g[5].Add(3);
            g[5].Add(6);
            g.AddList(6, new List<int>());
            g[6].Add(4);
            g[6].Add(5);

            //Console.WriteLine(String.Join(" ", AdjGraph.BreadthFirstSearch(g).Select(x=> x+"")));

            Console.WriteLine(AdjGraph.GetShortestPathUsingBFS(g,0,6));


        }
    }
}
