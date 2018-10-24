using System.Collections.Generic;
using System.Text;
using GraphNet.Exceptions;

namespace GraphNet
{
    /// <summary>
    /// The Graphviz graph base object. It can add one or more attributes to description. 
    /// </summary>
    public abstract class BaseGraphObject
    {
        private List<Attribute> _attributeList;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        protected BaseGraphObject(string id)
        {
            Id = id;
            _attributeList = new List<Attribute>();
        }

        public List<Attribute> AttributeList
        {
            get => _attributeList;
            private set => _attributeList = value;
        }

        /// <summary>
        /// Id of attribute
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Add an attribute to attribute list.
        /// </summary>
        /// <param name="attr"></param>
        public void AddAttribute(Attribute attr)
        {
            _attributeList.Add(attr);
        }

        /// <summary>
        /// Remove attribute by attribute name. 
        /// If this graph object has two or more attributes with the same name, it will remove them. 
        /// </summary>
        /// <param name="attributeName"></param>
        public void RemoveAttribute(string attributeName)
        {
            List<Attribute> removeList = new List<Attribute>();
            foreach(var attr in _attributeList)
            {
                if (attr.Name.Equals(attributeName))
                {
                    removeList.Add(attr);
                }
            }

            if(removeList.Count == 0)
            {
                throw new AttributeNotFoundException($"ID: {Id}; attribute: {attributeName}");
            }

            foreach(var attr in removeList)
            {
                _attributeList.Remove(attr);
            }

        }

        /// <summary>
        /// Attribute to dot string.
        /// </summary>
        /// <returns></returns>
        protected string ToAttributeDotString()
        {
            var attrDotString = new StringBuilder();
            foreach(var attr in _attributeList)
            {
                attrDotString.Append($"{attr.Name}={attr.Value};");
            }

            return attrDotString.ToString();
        }

        /// <summary>
        /// Convert this graph object to graphviz dot format. 
        /// </summary>
        /// <returns></returns>
        public abstract string ToDotString();

    }
}
