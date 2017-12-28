using System;

namespace KhanAldorithm
{
    public class KhanAlg
    {
        private readonly int[][] graph;
        private bool[] used;
        private readonly int[] matching;

        public KhanAlg(int n, int k, int[][] adjacencyList)
        {
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

        public int[] GetMatch(int n)
        {
            for (int i = 0; i < n; i++)
            {
                used = new bool[n];
                for (var v = 0; v < n; v++)
                {
                    used[v] = false;
                }
                DFS(i);
            }
            return matching;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            KhanAlg alg = new KhanAlg(5, 4, new []
            {
                new []{0}, 
                new []{0,2},
                new []{0},
                new []{2,3},
                new []{0}
            });
            int[] result = alg.GetMatch(5);
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != -1)
                {
                    Console.WriteLine($"A : {i} -> B: {result[i]}");
                }
            }
        }
    }
}
