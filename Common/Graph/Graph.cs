using System.Collections.Generic;

namespace CSharpDS
{
    class Graph
    {
        public Dictionary<Vertex, List<Vertex>> vertices;

        public Graph()
        {
            vertices = new Dictionary<Vertex, List<Vertex>>();
        }

        public void AddEdge(int val1, int val2)
        {

        }
    }

    class Vertex
    {
        public int value { get; private set; }

        public Vertex(int value)
        {
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vertex);
        }

        private bool Equals(Vertex other)
        {
            if (other == null)
                return false;

            return value == other.value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public override int GetHashCode()
        {
            return value;
        }
    }
}
