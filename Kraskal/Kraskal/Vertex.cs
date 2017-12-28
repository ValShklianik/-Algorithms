namespace Kraskal
{
    public class Vertex
    {
        private int index;

        public int Index { get; set; }
        public int Label { get; set; } = 0;

        public Vertex(int index)
        {
            Index = index;
        }

        public Vertex()
        {
            
        }
    }
}