namespace DataStructureDemosCSharp.Graph
{
    internal class GraphGeneric<T> where T : IEquatable<T>
    {
        private Dictionary<GraphGenericNode<T>, List<GraphGenericEdge<T>>> _graph;
        public bool Undirected { get; }
        public GraphGeneric(bool undirected = true)
        {
            _graph = new Dictionary<GraphGenericNode<T>, List<GraphGenericEdge<T>>>();
            Undirected = undirected;
        }

        public void AddNode(T? Data, bool forceClearEdge = false)
        {
            if (Data == null) return;

            // see if a node with the data exist
            GraphGenericNode<T> objectToFind = new GraphGenericNode<T>(Data);
            if (_graph.TryGetValue(objectToFind, out List<GraphGenericEdge<T>>? edgeList))
            {
                if (forceClearEdge)
                    _graph[objectToFind].Clear();
            }
            else
            {
                KeyValuePair<GraphGenericNode<T>, List<GraphGenericEdge<T>>> kvp = 
                    new KeyValuePair<GraphGenericNode<T>, List<GraphGenericEdge<T>>>(objectToFind, new List<GraphGenericEdge<T>>());
                _graph.Add(kvp.Key, kvp.Value);
            }
        }

        public void AddEdgeWithDataLookups(T? Data1, T? Data2, float weight = 0.0f)
        {
            if (Data1 == null || Data2 == null) return;
            GraphGenericNode<T> node1 = new GraphGenericNode<T>(Data1);
            if(_graph.TryGetValue(node1, out List<GraphGenericEdge<T>>? edges))
            {
                GraphGenericNode<T> node2 = new GraphGenericNode<T>(Data2);
                if (_graph.TryGetValue(node2, out List<GraphGenericEdge<T>>? edges2))
                {
                    //check to see if edge has already been added to node1
                    if (_graph[node1].Find(x => x.ToNode.Equals(node2)) == null)
                    {
                        _graph[node1].Add(new GraphGenericEdge<T>(node1, node2, weight));
                        if(Undirected)
                        {
                            _graph[node2].Add(new GraphGenericEdge<T>(node2, node1, weight));
                        }
                    }
                }
            }
        }

        public void PrintGraph()
        {
            foreach(var kvp in _graph)
            {
                string strKey = kvp.Key.ToString();
                Console.WriteLine($"\nConnections to {strKey}");
                for(int i = 0; i < kvp.Value.Count; i++)
                {
                    Console.WriteLine($"\tEdge to {kvp.Value[i].ToNode} with weight {kvp.Value[i].Weight}");
                }
            }
        }
    }

    internal class Point : IEquatable<Point>
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; } 
        public Point(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"X{X}, Y{Y}, Z{Z}";
        }

        public bool Equals(Point? other)
        {
            if (other == null) return false;
            return (X == other.X && Y == other.Y && Z == other.Z);
        }

        public override int GetHashCode()
        {
            unchecked 
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + Z.GetHashCode();
                return hash;
            }
        }
    }

    internal class GraphGenericNode<T> : IEquatable<GraphGenericNode<T>>
    {
        public T? Data { get; }        

        public GraphGenericNode(T data)
        {
            Data = data;            
        }        

        public bool Equals(GraphGenericNode<T>? other)
        {
            if (other == null) return false;
            return EqualityComparer<T>.Default.Equals(Data, other.Data);
        }

        public override int GetHashCode()
        {
            if (Data == null) throw new InvalidOperationException("Attempting to generate a hash code of a null Data value");
            return Data.GetHashCode();
        }        

        public override string ToString()
        {
            if (Data == null) return "";
            return Data.ToString();
        }
    }

    internal class GraphGenericEdge<T>
    {
        public GraphGenericNode<T> FromNode { get; }
        public GraphGenericNode<T> ToNode { get; }
        public float Weight { get; set; }

        public GraphGenericEdge(GraphGenericNode<T> fromNode, GraphGenericNode<T> toNode, float weight)
        {
            FromNode = fromNode;
            ToNode = toNode;
            Weight = weight;
        }
    }
}
