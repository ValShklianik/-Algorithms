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
        private bool[] used;
        private int[] matching;
        public int N { get; set; }
        private int K { get; set; }

        public KhanAlg(int n, int k, int[][] adjacencyList)
        {
            N = n;
            K = k;
            matching = new int[k];
            for (var v = 0; v < k; v++)
            {
                matching[v] = -1;
            }
            graph = adjacencyList;
        }

        private bool DFS(int vertex)
        {
            if (used[vertex]) return false;
            used[vertex] = true;
            foreach (var to in graph[vertex])
            {
                if (matching[to] == -1 || DFS(matching[to]))
                {
                    matching[to] = vertex;
                    return true;
                }
            }
            return false;
        }

        public int[] getMatch()
        {
            for (int i = 0; i < N; i++)
            {
                used = new bool[N];
                for (var v = 0; v < N; v++)
                {
                    used[v] = false;
                }
                DFS(i);
            }
            return matching;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KhanAlg alg = new KhanAlg(5, 4, new []
            {
                new []{0}, 
                new []{0, 1, 2},
                new []{1},
                new []{2},
                new []{1, 2, 3, 10}
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
