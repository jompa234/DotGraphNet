namespace GraphNet
{
    public class Edge : BaseGraphObject
    {
        /// <summary>
        /// Edge constructor with edge id. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fromNode"></param>
        /// <param name="toNode"></param>
        public Edge(string id, Node fromNode, Node toNode) : base(id)
        {
            FromNode = fromNode;
            ToNode = toNode;
        }

        /// <summary>
        /// Edge constructor without edge id. Default edge id is empty string. 
        /// </summary>
        /// <param name="fromNode"></param>
        /// <param name="toNode"></param>
        public Edge(Node fromNode, Node toNode) : base("")
        {
            FromNode = fromNode;
            ToNode = toNode;
        }

        /// <summary>
        /// From Node
        /// </summary>
        public Node FromNode { get; }

        /// <summary>
        /// To Node
        /// </summary>
        public Node ToNode { get; }

        /// <inheritdoc />
        public override string ToDotString()
        {
            if (AttributeList.Count > 0)
            {
                return $"[{ToAttributeDotString()}]";
            }

            return string.Empty;
        }
    }
}
