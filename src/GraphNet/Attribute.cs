namespace GraphNet
{
    public class Attribute
    {
        public Attribute(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Attribute Name. Like 'label' 'color' ...etc.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Attribute Value. Like 'blue' ...etc
        /// </summary>
        public string Value { get; set; }

    }
}
