namespace Kraskal
{
    public class Edge
    {
        public int start;
        public int end;
        public int weight;
        private int label = 0;
        public Vertex startVertex = new Vertex();
        public Vertex endVertex = new Vertex();

        public int Label
        {
            get => label;

            set
            {
                label = value;
                startVertex.Label = value;
                endVertex.Label = value;
            }
        }

        public Edge()
        {
            startVertex.Label = label;
            startVertex.Index = start;
            endVertex.Label = Label;
            endVertex.Index = end;
        }

        public Edge(int start, int end, int weight) : this()
        {
            this.start = start;
            this.end = end;
            this.weight = weight;
        }


    }
}