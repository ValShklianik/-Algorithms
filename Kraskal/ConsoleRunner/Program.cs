using System;
using Kraskal;

namespace ConsoleRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var edgeList = new EdgeList();
            edgeList.Add(1, 2, 7);
            edgeList.Add(1, 4, 5);
            edgeList.Add(2, 3, 8);

            edgeList.Add(4, 5, 15);
            edgeList.Add(4, 6, 6);
            edgeList.Add(5, 6, 8);

            edgeList.Add(2, 4, 9);
            edgeList.Add(2, 5, 7);
            edgeList.Add(3, 5, 5);

            edgeList.Add(5, 7, 9);
            edgeList.Add(6, 7, 11);

            edgeList.ShowEdges();
            Console.WriteLine();

            KraskalAlgorithm kr = new KraskalAlgorithm();
            kr.ShowEdges(kr.KraskalsAlgorithm(edgeList.GetEdges()));

            Console.ReadLine();
        }
    }
}
