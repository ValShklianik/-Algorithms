using System;
using System.Collections.Generic;
using System.Linq;

namespace Kraskal
{
    public class KraskalAlgorithm
    {
        private SortedList<(int, int), Edge> result = new SortedList<(int, int), Edge>();
        private int countLabel;

        public void CheckCycle(int start, int end, int weight)
        {
            var firstAdjacentVertex = (0, 0);
            var secondAdjacentVertex = (0, 0);
            Vertex firstVertex = new Vertex();
            Vertex secVertex = new Vertex();

            foreach (var edge in result)
            {
                if (edge.Value.start == start)
                {
                    
                    firstAdjacentVertex = (edge.Value.start, edge.Value.end);
                    firstVertex= edge.Value.startVertex;
                    break;
                  
                }

                if (edge.Value.end == start)
                {
                    firstAdjacentVertex = (edge.Value.start, edge.Value.end);
                    firstVertex = edge.Value.endVertex;
                    break;
                }
            }
            foreach (var edge in result)
            {
                if (edge.Value.start == end)
                {
                    secondAdjacentVertex = (edge.Value.start, edge.Value.end);
                    secVertex = edge.Value.startVertex;
                    break;
                }

                if (edge.Value.end == end)
                {
                    secondAdjacentVertex = (edge.Value.start, edge.Value.end);
                    secVertex = edge.Value.endVertex;                    
                    break;
                }
            }
            

            if (firstAdjacentVertex.Equals((0, 0)) && secondAdjacentVertex.Equals((0, 0)))
            {
                countLabel++;
                AddToResult(start, end, weight, countLabel);


            }

            if (!firstAdjacentVertex.Equals((0, 0)) && secondAdjacentVertex.Equals((0, 0)))
            {
                AddToResult(start, end, weight, result[firstAdjacentVertex].Label);
            }

            if (!firstAdjacentVertex.Equals((0, 0)) && !secondAdjacentVertex.Equals((0, 0)))
            {
                if (firstVertex.Label != secVertex.Label)
                {
                    AddToResult(start, end, weight, firstVertex.Label);
                    FindAdjacentAndChangeLabel(firstVertex.Label, secVertex.Label);
                }
            }
        }

        private void FindAdjacentAndChangeLabel(int firstLabel, int secondLabel)
        {
            foreach (var edge in result)
            {
                if (edge.Value.Label == secondLabel)
                {
                    edge.Value.Label = firstLabel;
                }
            }
        }

        public void AddToResult(int start, int end, int weight)
        {
            if (start < end)
            {
                result.Add((start, end), new Edge(start, end, weight));
            }
            else
            {
                result.Add((end, start), new Edge(end, start, weight));
            }
        }

        public SortedList<(int, int), Edge> KraskalsAlgorithm(SortedList<(int, int), Edge> currList)
        {
            foreach (var edge in currList.OrderBy(edge => edge.Value.weight))
            {
                CheckCycle(edge.Value.start, edge.Value.end, edge.Value.weight);
            }

            return result;
        }

        public void ShowEdges(SortedList<(int, int), Edge> list)
        {
            foreach (var edge in list.OrderBy(edge => edge.Value.weight))
            {
                Console.WriteLine($"{edge.Key} {edge.Value.weight} {edge.Value.Label}");
            }
        }

        public void AddToResult(int start, int end, int weight, int label)
        {
            Edge edge;
            if (start < end)
            {
                edge = new Edge(start, end, weight);
                edge.Label = label;
                result.Add((start, end), edge);
            }
            else
            {
                edge = new Edge(end, start, weight);
                edge.Label = label;
                result.Add((end, start), edge);
            }
        }

        public void AddToResult(Edge edge)
        {
        result.Add((edge.start, edge.end), new Edge(edge.start, edge.end, edge.weight));
        }
    }
}
