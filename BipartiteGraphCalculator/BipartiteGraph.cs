using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BipartiteGraphCalculator
{
    class BipartiteGraph
    {
        // CONSTRUCTORS

        public BipartiteGraph()
        {

        }

        /* NOT CURRENTLY USED!
        // Constructs a graph with vertexNo vertices and no edges.
        public BipartiteGraph(int vertexNo)
        {
            
        }
        */

        /* NOT CURRENTLY USED!
        public BipartiteGraph(int vertexNo, params Edge[] edges)
        {
            
        }
        */


        // FIELDS

        // A bipartite graph is determined by its set of left and right vertices and edges.
        List<Vertex> _leftVertices = new List<Vertex>();
        List<Vertex> _rightVertices = new List<Vertex>();
        List<Vertex> _vertices = new List<Vertex>();
        List<Edge> _edges = new List<Edge>();


        // PROPERTIES

        public int CountVertices
        {
            get { return _vertices.Count(); }
        }

        public int CountLeftVertices
        {
            get { return _leftVertices.Count(); }
        }

        public int CountRightVertices
        {
            get { return _rightVertices.Count(); }
        }

        public int CountEdges
        {
            get { return _edges.Count(); }
        }


        // METHODS

        public void AddLeftVertex()
        {
            _leftVertices.Add(new Vertex());
            _vertices.Add(_leftVertices[_leftVertices.Count - 1]);
        }

        public void AddRightVertex()
        {
            _rightVertices.Add(new Vertex());
            _vertices.Add(_rightVertices[_rightVertices.Count - 1]);
        }

        /* NOT CURRENTLY USED!
        public void RemoveVertex(Vertex vertex) 
        {

        }
        */

        // Add an edge, as well as tying the vertices to the edge
        public void AddEdge(int i, int j)
        {
            // NEEDS TRY CATCH
            Edge edge = new Edge(_leftVertices[i - 1], _rightVertices[j - 1]);
            _edges.Add(edge);
            _leftVertices[i - 1].AddEdges(edge);
            _rightVertices[j - 1].AddEdges(edge);
        }

        /* NOT CURRENTLY USED!
        public void RemoveEdge(Edge edge)
        {

        }
        */

        // Returns true if the graph has an edge between these vertices
        public bool HasEdge(int i, int j)
        {
            foreach (Edge edge in _edges)
            {
                if (_leftVertices.IndexOf(edge._edgeEnds[0]) == i - 1
                    && _rightVertices.IndexOf(edge._edgeEnds[1]) == j - 1)
                {
                    return true;
                }
            }
            return false;
        }

        // Count number of components using breadth-first search
        public int CountComponents()
        // Works by defining a frontier, starting at a single vertex. In order of when they
        // were added to the frontier, each vertex is replaced by its adjacent vertices that
        // haven't yet been reached.
        // The ``breadth-first" nature of the algorithm is in the queue behaviour

        {
            int componentsNo = 0;
            List<Vertex> remainingVertices = new List<Vertex>(_vertices);
            Queue<Vertex> frontierVertices = new Queue<Vertex>();

            Vertex frontierVertex;

            while (remainingVertices.Any() == true)
            {
                componentsNo++;
                frontierVertices.Enqueue(remainingVertices.First());

                while (frontierVertices.Any())
                {
                    frontierVertex = frontierVertices.First();
                    List<Vertex> adjacentVertices = frontierVertex.AdjacentVertices();

                    foreach (Vertex vertex in adjacentVertices)
                    {
                        if (remainingVertices.Contains(vertex) &&
                            !frontierVertices.Contains(vertex))
                        {
                            frontierVertices.Enqueue(vertex);
                        }
                    }
                    frontierVertices.Dequeue();
                    remainingVertices.Remove(frontierVertex);
                }
            }
            return componentsNo;
        }
    }
}

