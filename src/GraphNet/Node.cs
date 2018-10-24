namespace GraphNet
{
    public class Node : BaseGraphObject
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public Node(string id) : base(id)
        {

        }

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
