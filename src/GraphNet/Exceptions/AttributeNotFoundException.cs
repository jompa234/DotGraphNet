namespace GraphNet.Exceptions
{
    public class AttributeNotFoundException : GraphvizApiException
    {
        private const string Idtag = "GRAPH ID:";
        private const string Attrtag = "Attrbute : ";

        public AttributeNotFoundException(string message) : base(message)
        {
        }
    }
}
