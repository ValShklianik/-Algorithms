using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Kraskal
{
    public class EdgeList
    {
        private SortedList<(int, int), Edge> edgeList = new SortedList<(int, int), Edge>();
        private List<int> vss = new List<int>();

        public EdgeList(EdgeList toCopy)
        {
            foreach (var edge in toCopy.edgeList.Values)
            {
                this.Add(edge.start, edge.end, edge.weight);
            }
        }

        private void AddVsToList(int vertex1, int vertex2)
        {
            if (!vss.Contains(vertex1))
            {
                vss.Add(vertex1);
            }
            if (!vss.Contains(vertex2))
            {
                vss.Add(vertex2);
            }
        }

        public EdgeList()
        {
        }

        public int GetAmountOfVs()
        {
            return vss.Count;
        }

        public int Total { private set; get; } = 0;

        public SortedList<(int, int), Edge> GetEdges()
        {
            return edgeList;
        }

        public void ShowEdges()
        {
            foreach (var edge in edgeList.OrderBy(edge => edge.Value.weight))
            {
                Console.WriteLine($"{edge.Key} {edge.Value.weight}");
            }
        }

        public void Add(int start, int end, int weight)
        {
            if (start < end)
            {
                edgeList.Add((start, end), new Edge(start, end, weight));
            }
            else
            {
                edgeList.Add((end, start), new Edge(end, start, weight));
            }
            AddVsToList(start, end);
            Total += weight;
        }

        public void Remove(int start, int end)
        {
            int weight;
            if (start < end)
            {
                weight = edgeList[(start, end)].weight;
                edgeList.Remove((start, end));
            }
            else
            {
                weight = edgeList[(end, start)].weight;
                edgeList.Remove((end, start));
            }
            Total -= weight;
        }

        public bool Contains(int start, int end)
        {
            if (start < end)
            {
                return edgeList.ContainsKey((start, end));
            }
            else
            {
                return edgeList.ContainsKey((end, start));
            }
        }

        public int GetWeight(int start, int end)
        {
            if (start < end)
            {
                return edgeList[(start, end)].weight;
            }
            else
            {
                return edgeList[(end, start)].weight;
            }
        }
    }
}