using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace KhanAldorithm
{
    public class KhanAlg
    {
        private int[][] graph;

        public KhanAlg(int[][] adjacencyList)
        {
            graph = adjacencyList;
        }

        private bool DFS(bool[] used, int[] matching, int vertex)
        {
            if (used[vertex]) return false;
            used[vertex] = true;
            foreach (var to in graph[vertex])
            {
                if (matching[to] == -1 || DFS(used, matching, matching[to]))
                {
                    matching[to] = vertex;
                    return true;
                }
            }
            return false;
        }

        public int[] getMatch()
        {
            int[] matching = graph.Select(x => -1).ToArray();
            for (int i = 0; i < matching.Length; i++)
            {
                bool[] used = matching.Select(x => false).ToArray();
                DFS(used, matching, i);
            }
            return matching;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KhanAlg alg = new KhanAlg(new []
            {
                new []{1}, 
                new []{2, 0},
                new []{3, 4, 1},
                new []{5, 2},
                new []{6, 2},
                new []{3},
                new []{4}
            });
            int[] result = alg.getMatch();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != -1)
                {
                    Console.WriteLine($"({i}, {result[i]})");
                }
            }
        }
    }
}
