using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerCycle
{

    class ExecuteEulerCircuit
    {
        static void Main(string[] args)
        {
            var graph = new Graph(9);

            //G = {0: [1, 4, 6, 8], 1: [0, 2, 3, 8], 2: [1, 3], 3: [1, 2, 4, 5], 4: [0, 3], 5: [3, 6], 6: [0, 5, 7, 8], 7: [6, 8], 8: [0, 1, 6, 7]}
            graph.Connect(0, 1);
            graph.Connect(0, 4);
            graph.Connect(0, 6);
            graph.Connect(0, 8);

            graph.Connect(1, 2);
            graph.Connect(1, 3);
            graph.Connect(1, 8);

            graph.Connect(2, 3);

            graph.Connect(3, 4);
            graph.Connect(3, 5);

            graph.Connect(5, 6);

            graph.Connect(6, 7);
            graph.Connect(6, 8);

            graph.Connect(7, 8);

            var eulerTour = new EulerTour(graph);

            IEnumerable<Node> cycle = eulerTour.GetCycle();

            foreach (var v in cycle)
            {
                Console.Write(v.number + " ");
            }
            Console.ReadKey();
        }
    }
}
