using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace GraphNet
{
    public class Graphviz
    {
        private static string _dot = "dot";
        private static string _tmpPath = "/tmp";

        public Graphviz()
        {

        }

        /// <summary>
        /// Constructor with custom dot command like "/usr/bin/dot". 
        /// And custom tmp file path.
        /// Make sure user have writable permission.
        /// </summary>
        /// <param name="dotPath"></param>
        /// <param name="tmpPath"></param>
        public Graphviz(string dotPath, string tmpPath)
        {
            _dot = dotPath;
            _tmpPath = tmpPath;
        }

        /// <summary>
        /// The tmp file path setter.
        /// </summary>
        public string TempPath
        {
            get
            {
                return _tmpPath;
            }
        }

        public byte[] GetGraphByteArray(Graph graph, string type, string dpi)
        {
            var dotSource = GenDotStringByGraph(graph);

            byte[] imgStream = null;
            string dot = string.Empty;
            dot = WriteDotSourceToFile(dotSource);

            //todo: call dot.dll process etc. 

            return null;
        }

        private string GenDotStringByGraph(Graph graph)
        {
            var dotString = new StringBuilder();

            if (graph.GraphType == GraphType.Digraph)
            {
                dotString.Append("digraph ");
            }
            else if(graph.GraphType == GraphType.Grpah)
            {
                dotString.Append("graph ");
            }
            else
            {
                Debug.Assert(true);
            }

            dotString.Append(graph.Id);
            dotString.Append(graph.ToDotString());
            return dotString.ToString();
        }

        private string WriteDotSourceToFile(string str)
        {
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, str);
            return tempFile;
        }

        private byte[] get_img_stream(string dot, String type, String representationType, String dpi)
        {
            throw new NotImplementedException();
        }
    }
}
