using System.Collections.Generic;
using System.Text;
using GraphNet.Exceptions;

namespace GraphNet
{
    /// <summary>
    /// Graph or subgraph
    /// </summary>
    public class Graph : BaseGraphObject
    {
        private List<Node> _nodeList;
        private List<Edge> _edgeList;
        private List<Graph> _subgraphList;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="graphType"></param>
        /// <param name="isStrict"></param>
        public Graph(string id, GraphType graphType, bool isStrict) : base(id)
        {
            GraphType = graphType;
            IsStrict = isStrict;
            this._nodeList = new List<Node>();
            this._edgeList = new List<Edge>();
            this._subgraphList = new List<Graph>();
        }

        /// <summary>
        /// Indicates wether or not this graph is strict. 
        /// A strict graph forbids the creation of mlti-edges, i.e there can be at most one edge with a given tail node and head node in the directed case.
        /// </summary>
        public bool IsStrict { get; set; }

        /// <summary>
        /// Type of graph.
        /// A graph must be specified as either a diagraph or a graph. 
        /// Indicates whether or not there is a natural direction from one of the edge's nodes to the other.
        /// </summary>
        public GraphType GraphType { get; }

        /// <summary>
        /// Add node to graph
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(Node node)
        {
            _nodeList.Add(node);
        }

        /// <summary>
        /// Add edge to graph
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(Edge edge)
        {
            _edgeList.Add(edge);
        }

        /// <summary>
        /// Add subgraph to graph
        /// </summary>
        /// <param name="graph"></param>
        public void AddSubgraph(Graph graph)
        {
            _subgraphList.Add(graph);
        }

        /// <summary>
        /// Return full dot-string for graph, including header.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public string ToDotStringWithHeader()
        {
            var dotString = new StringBuilder();

            if (GraphType == GraphType.Digraph)
            {
                dotString.Append("digraph ");
            }
            else if (GraphType == GraphType.Grpah)
            {
                dotString.Append("graph ");
            }

            dotString.Append(Id);
            dotString.Append(ToDotString());
            return dotString.ToString();
        }

        /// <inheritdoc />
        public override string ToDotString()
        {
            var dotString = new StringBuilder();
            dotString.Append("{\n");
            dotString.Append(ToAttributeDotString());
            dotString.Append("\n");
            dotString.Append(ToSubgraphString());
            dotString.Append(ToNodesString());
            dotString.Append(ToEdgeDotString());
            dotString.Append("}\n");
            return dotString.ToString();
        }

        /// <summary>
        /// Returns dot-language string representation of subgraph.
        /// </summary>
        /// <returns></returns>
        private string ToSubgraphString()
        {
            var subgraphString = new StringBuilder();

            foreach(var graph in _subgraphList)
            {
                subgraphString.Append("subgraph ");
                subgraphString.Append(graph.Id);
                subgraphString.Append(graph.ToDotString());
                subgraphString.Append("\n");
            }

            return subgraphString.ToString();
        }

        /// <summary>
        /// Returns dot-language string representation of node.
        /// </summary>
        /// <returns></returns>
        private string ToNodesString()
        {
            var nodeString = new StringBuilder();
            foreach (var node in _nodeList)
            {
                nodeString.Append(node.Id);
                nodeString.Append(node.ToDotString());
                nodeString.Append("\n");
            }
            return nodeString.ToString();
        }

        /// <summary>
        /// Returns dot-language string representation of edge.
        /// </summary>
        /// <returns></returns>
        private string ToEdgeDotString()
        {
            var edgeString = new StringBuilder();
            foreach (var edge in _edgeList)
            {
                edgeString.Append(edge.FromNode.Id + GetLinkString() + edge.ToNode.Id);
                edgeString.Append(edge.ToDotString());
                edgeString.Append("\n");
            }
            return edgeString.ToString();
        }

        /// <summary>
        /// Get dot-language string representation of the connection/link between two nodes in the graph.
        /// </summary>
        /// <returns></returns>
        private string GetLinkString()
        {
            if(GraphType == GraphType.Digraph)
            {
                return "->";
            }
            else if(GraphType == GraphType.Grpah)
            {
                return "--";
            }
            else
            {
                throw new GraphException("Not Supported Graph Type.");
            }
        }
    }
}
