using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BipartiteGraphCalculator
{
    class Edge
    {
        // Pair of end vertices of the edge
        public List<Vertex> _edgeEnds
        { get; set; } = new List<Vertex>();

        // Constructor using two end vertices
        public Edge(Vertex end1, Vertex end2)
        {
            _edgeEnds.Add(end1);
            _edgeEnds.Add(end2);
        }

        // Return the edge end not equal to the argument vertex
        public Vertex EdgeEnds(Vertex vertex)
        {
            if (_edgeEnds.IndexOf(vertex) == 0)
            {
                return _edgeEnds[1];
            }
            else
            {
                return _edgeEnds[0];
            }
        }
    }
}