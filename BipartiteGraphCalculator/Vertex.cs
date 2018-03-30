using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BipartiteGraphCalculator
{
    class Vertex
    {
        List<Edge> _adjacentEdges = new List<Edge>(); // Set of adjacent edges

        public Vertex()
        {

        }

        /* NOT CURRENTLY USED!
        public Vertex(params Edge[] edges)
        {
            foreach (Edge edge in edges)
            {
                _adjEdges.Add(edge);
            }
        }
        */

        // Add edges to the set of adjacent edges
        public void AddEdges(params Edge[] edges)
        {
            foreach (Edge edge in edges)
            {
                _adjacentEdges.Add(edge);
            }
        }

        // Return adjacent vertices
        public List<Vertex> AdjacentVertices()
        {
            List<Vertex> adjacentVertices = new List<Vertex>();
            foreach (Edge edge in _adjacentEdges)
            {
                adjacentVertices.Add(edge.EdgeEnds(this));
            }

            return adjacentVertices;
        }
    }
}
