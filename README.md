# DotGraphNet

DotGraphNet is a small and simple library for creating simple graphs.

The api let's you create objects representing graphs, sub-graphs, nodes and edges in code.
Then the graph can be converted into a file written in the dot-language for further processing with the open source graph visualization software Graphviz. 

Written in c# .net standard. 

Based on:
https://github.com/eternnoir/graphvizapi

# Ideas for further work: 
- Supported attributes for the dot-language and the layout engines in code.
- Direct integration into graphviz layout engine?
- Include own layout engine?
- Include own renderers?


# Documentation


# Examples

## Create a graph in code: 

            Graphviz gv = new Graphviz();
            Graph graph = new Graph("g1", GraphType.Digraph,false);
            Graph cluster_0 = new Graph("cluster_0", GraphType.Digraph,false);
            cluster_0.AddAttribute(new Attribute("style", "filled"));
            cluster_0.AddAttribute(new Attribute("color", "lightgrey"));
            cluster_0.AddAttribute(new Attribute("label", "\"process #1\""));
            Attribute cn0Attr = new Attribute("style", "filled");
            Node a0 = new Node("a0");
            Node a1 = new Node("a1");
            Node a2 = new Node("a2");
            Node a3 = new Node("a3");
            cluster_0.AddNode(a0);
            cluster_0.AddNode(a1);
            cluster_0.AddNode(a2);
            cluster_0.AddNode(a3);
            cluster_0.AddEdge(new Edge(a0, a1));
            cluster_0.AddEdge(new Edge(a1, a2));
            cluster_0.AddEdge(new Edge(a2, a3));
            Graph cluster_1 = new Graph("cluster_1", GraphType.Digraph,false);
            cluster_1.AddAttribute(new Attribute("color", "blue"));
            cluster_1.AddAttribute(new Attribute("label", "\"process #1\""));
            Node b0 = new Node("b0");
            Node b1 = new Node("b1");
            Node b2 = new Node("b2");
            Node b3 = new Node("b3");
            cluster_1.AddNode(b0);
            cluster_1.AddNode(b1);
            cluster_1.AddNode(b2);
            cluster_1.AddNode(b3);
            cluster_1.AddEdge(new Edge(b0, b1));
            cluster_1.AddEdge(new Edge(b1, b2));
            cluster_1.AddEdge(new Edge(b2, b3));
            Node startNode = new Node("Start");
            startNode.AddAttribute(new Attribute("shape", "Mdiamond"));
            Node endNode = new Node("End");
            endNode.AddAttribute(new Attribute("shape", "Msquare"));
            graph.AddNode(startNode);
            graph.AddNode(endNode);
            graph.AddSubgraph(cluster_0);
            graph.AddSubgraph(cluster_1);
            graph.AddEdge(new Edge(startNode, a0));
            graph.AddEdge(new Edge(startNode, b0));
            graph.AddEdge(new Edge(a1, b3));
            graph.AddEdge(new Edge(b2, a3));
            graph.AddEdge(new Edge(a3, a0));
            graph.AddEdge(new Edge(a3, endNode));
            graph.AddEdge(new Edge(b3, endNode));

            var g = graph.ToDotStringWithHeader();

## How to run the generated dot-file:

### From the command line: 

dot.exe -Tpng inputfile.dot -o outfile.png

Dot.exe is the executable for the dot layout engine. Graphviz comes with multiple layout engines. There are executables for other layout engines like neato and twopi. 

The argument -T defines the rendered output format. Graphviz supports a range of formats to render to. Some nice examples are -Tpng for Portable Network Graphics (PNG) image files and -Tpdf for portable document format (PDF). 

See http://www.graphviz.org/doc/info/output.html for the supported output formats. 

### Graphviz GUI: 

Graphviz comes with a simple editor for creating graphs called GVEdit. It is located in the installations bin directory and has the name gvedit.exe. 



# License

MIT License
