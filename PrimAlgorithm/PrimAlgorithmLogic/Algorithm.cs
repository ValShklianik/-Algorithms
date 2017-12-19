using System;
using System.Collections.Generic;
using PrimAlgorithmLogic.GraphLogic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimAlgorithmLogic
{
    public static class Algorithm
    {
        public static List<Edge> Prim(Graph graph, Dictionary<Edge, double> weights)
        {
            var notVisitedEdges = graph.Edges.ToList();
            var MST = new List<Edge>();
            var visitedNodes = new List<Node>();

            Random rand = new Random();

            visitedNodes.Add(graph[rand.Next(0, graph.Length-1)]);


            while (visitedNodes.Count <= graph.Length)
            {
                int minEdge = -1;
                foreach (var node in visitedNodes)
                {
                    foreach (var e in node.IncidentEdges)
                    {
                        if (notVisitedEdges.Contains(e))
                        {
                            if (minEdge != -1)
                            {
                                if (weights[e] < weights[notVisitedEdges[minEdge]] &&
                                    visitedNodes.IndexOf(e.OtherNode(node)) == -1)
                                    minEdge = notVisitedEdges.IndexOf(e);
                            }
                            else
                            {
                                if (visitedNodes.IndexOf(e.OtherNode(node)) == -1) minEdge = notVisitedEdges.IndexOf(e);
                            }

                        }
                    }
                }


                if (minEdge == -1) return MST;
                Node toAdd = visitedNodes.IndexOf(notVisitedEdges[minEdge].to) == -1
                    ? notVisitedEdges[minEdge].to
                    : notVisitedEdges[minEdge].from;
                visitedNodes.Add(toAdd);

                MST.Add(notVisitedEdges[minEdge]);
                notVisitedEdges.Remove(notVisitedEdges[minEdge]);                         
            }
            return MST;

        }

        static void Main(string[] args)
        {
            var graph = new Graph(8);
            var weights = new Dictionary<Edge, double>();
            weights[graph.Connect(0, 2)] = 2;
            weights[graph.Connect(3, 2)] = 6;
            weights[graph.Connect(1, 3)] = 4;
            weights[graph.Connect(2, 4)] = 2;
            weights[graph.Connect(3, 5)] = 3;
            weights[graph.Connect(4, 5)] = 9;
            weights[graph.Connect(4, 6)] = 2;
            weights[graph.Connect(5, 7)] = 4.4;
            weights[graph.Connect(5, 6)] = 5;
            weights[graph.Connect(1, 6)] = 1;
            weights[graph.Connect(0, 4)] = 4;


            var res = Prim(graph, weights);
            foreach (var e in res )
            {
                Console.Write(e);
            }
            
        }
    }
}
