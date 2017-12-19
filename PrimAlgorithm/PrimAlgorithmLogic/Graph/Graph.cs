using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimAlgorithmLogic.GraphLogic
{
    public class Edge
    {
        public readonly Node from;
        public readonly Node to;

        public Edge(Node from, Node to)
        {
            this.from = from;
            this.to = to;
        }

        public bool IsIncident(Node node)
        {
            return from == node || to == node;
        }

        public Node OtherNode(Node node)
        {
            if (!IsIncident(node)) throw new ArgumentException();
            if (from == node) return to;
            return from;
        }

        public override string ToString()
        {
            return $"({to}, {from})";
        }

        public override bool Equals(object obj)
        {
            return (((Edge) obj)?.from == from || ((Edge) obj)?.from == to) &&
                   (((Edge) obj)?.to == from || ((Edge) obj)?.to == to);
        }

        public override int GetHashCode()
        {
            return to.number + from.number;
        }
    }

    public class Node
    {

        readonly List<Edge> edges = new List<Edge>();
        public readonly int number;

        public Node(int number)
        {
            this.number = number;
        }

        public IEnumerable<Node> IncidentNodes
        {
            get
            {
                return edges.Select(z => z.OtherNode(this));
            }
        }

        public IEnumerable<Edge> IncidentEdges
        {
            get
            {
                foreach (var e in edges) yield return e;
            }
        }

        public static Edge Connect(Node node1, Node node2, Graph graph)
        {
            if (!graph.Nodes.Contains(node1) || !graph.Nodes.Contains(node2)) throw new ArgumentException();
            var edge = new Edge(node1, node2);
            node1.edges.Add(edge);
            node2.edges.Add(edge);
            return edge;
        }

        public override string ToString()
        {
            return number.ToString();
        }

        /*public static void Disconnect(Edge edge)
        {
            edge.from.edges.Remove(edge);
            edge.to.edges.Remove(edge);
        }*/
    }

    public class Graph
    {
        private List<Node> nodes;

        public Graph(int nodesCount)
        {
            nodes = Enumerable.Range(0, nodesCount).Select(z => new Node(z)).ToList();
        }

        public int Length { get => nodes.Count; }

        public Node this[int index] { get => nodes[index]; }


        public IEnumerable<Node> Nodes
        {
            get
            {
                foreach (var node in nodes) yield return node;
            }
        }

        public Edge Connect(int index1, int index2)
        {
            return Node.Connect(nodes[index1], nodes[index2], this);
        }

        /*public void Delete(Edge edge)
        {
            Node.Disconnect(edge);
        }*/

        public IEnumerable<Edge> Edges
        {
            get
            {
                return nodes.SelectMany(z => z.IncidentEdges).Distinct();
            }
        }

        /*public static Graph MakeGraph(params int[] incidentNodes)
        {
            var graph = new Graph(incidentNodes.Max() + 1);
            for (int i = 0; i < incidentNodes.Length - 1; i += 2)
                graph.Connect(incidentNodes[i], incidentNodes[i + 1]);
            return graph;
        }*/
    }
}
