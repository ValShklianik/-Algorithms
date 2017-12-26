using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerCycle
{
    public class EulerTour
    {
        private Graph graph;

        public EulerTour(Graph g)
        {
            graph = new Graph(g.Length);

            foreach (var edge in g.Edges)
            {
                graph.Connect(edge.from.number, edge.to.number);
            }
        }

        public IEnumerable<Node> GetCycle()
        {
            var stack = new Stack<Node>();
            var answer = new List<Node>();

            stack.Push(graph.Nodes.First());
      
            while (stack.Count > 0)
            {
                Node v = stack.Peek();
                if (v.IncidentEdges.Any())
                {
                    Edge e = v.IncidentEdges.First();
                    stack.Push(e.OtherNode(v));
                    graph.Delete(e);
                }
                else
                {
                    answer.Add(stack.Pop());
                }
            }
            return answer;
        }
    }
}
