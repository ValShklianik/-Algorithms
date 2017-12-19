using System;
using System.Collections.Generic;
using System.Linq;
using DijkstraLogic.GraphLogic;

namespace DijkstraLogic
{
    class DijkstraData
    {
        public Node Previous { get; set; }
        public double Price { get; set; }
    }

    public class Algorithm
    {
        public static List<Node> Dijkstra(Graph graph, Dictionary<Edge, double> weights, Node start, Node end)
        {
            if (weights == null || start == null || end == null)
            {
                throw new ArgumentNullException(nameof(weights));
            }

            var notVisited = graph.Nodes.ToList();
            var track = new Dictionary<Node, DijkstraData>
            {
                { start, new DijkstraData { Price = 0, Previous = null } },
            };


            while (true)
            {
                Node toOpen = null;
                var bestPrice = double.PositiveInfinity;
                foreach (var e in notVisited)
                {
                    if (track.ContainsKey(e) && track[e].Price < bestPrice)
                    {
                        bestPrice = track[e].Price;
                        toOpen = e;
                    }
                }

                if (toOpen == null) return null;
                if (toOpen == end) break;

                //foreach (var e in toOpen.IncidentEdges)
                foreach (var e in toOpen.IncidentEdges.Where(z => z.from == toOpen))
                {

                    var currentPrice = track[toOpen].Price + weights[e];
                    var nextNode = e.OtherNode(toOpen);
                    if (!track.ContainsKey(nextNode) || track[nextNode].Price > currentPrice)
                    {
                        track[nextNode] = new DijkstraData { Previous = toOpen, Price = currentPrice };
                    }
                }
                notVisited.Remove(toOpen);  
            }

            var result = new List<Node>();
            while (end != null)
            {
                result.Add(end);
                end = track[end].Previous;
            }
            result.Reverse();
            return result;
        }
        public static void Main()
        {
            var graph = new Graph(8);
            var weights = new Dictionary<Edge, double>();
            weights[graph.Connect(0, 1)] = 1;
            weights[graph.Connect(0, 2)] = 2;
            weights[graph.Connect(0, 3)] = 6;
            weights[graph.Connect(1, 3)] = 4;
            weights[graph.Connect(2, 3)] = 2;
            weights[graph.Connect(3, 5)] = 3;
            weights[graph.Connect(4, 5)] = 1;
            weights[graph.Connect(4, 6)] = 2;
            weights[graph.Connect(5, 7)] = 4.4;
            weights[graph.Connect(5, 6)] = 5;

            /*for(int i = 0; i < graph.Length; i++)
            {
                var path = Dijkstra(graph, weights, graph[0], graph[i]).Select(n => n.number);
                foreach (var p in path)
                {
                    Console.Write( $"{p} , ");

                }
                Console.WriteLine($"track from 0 to {i}");
            }*/
            var path2 = Dijkstra(graph, weights, graph[0], graph[6]).Select(n => n.number);

           
            Console.WriteLine();

            foreach (var p in path2)
            {
                Console.Write(p + " , ");
            }
        }
    }
}
