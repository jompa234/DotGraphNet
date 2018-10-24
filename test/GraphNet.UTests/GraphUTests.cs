using System;
using Xunit;

namespace GraphNet.UTests
{
    public class GraphUTests
    {
        [Fact]
        public void GivenGraph_ToDotString_ShouldGenerateCorrectDotOutput()
        {
            var graph = new Graph("Graph1",GraphType.Grpah,false);
            var node1 = new Node("Node1");
            var node2 = new Node("Node2");
            var edge = new Edge(node1, node2);

            graph.AddNode(node1);
            graph.AddNode(node2);

            graph.AddEdge(edge);

            var actual = graph.ToDotString();

            Assert.Equal("{\n\nNode1\nNode2\nNode1--Node2\n}\n", actual);
        }

        [Fact]
        public void Example1()
        {
            Graph graph = new Graph("g1", GraphType.Digraph, false);       //Create New Gpaph.
            graph.AddAttribute(new Attribute("rankdir", "LR"));      //Add some attribute.
            var n1 = new Node("N1");                               //Create Node Object.
            n1.AddAttribute(new Attribute("label","\" Node1 \""));  //Add attribute
            var n2 = new Node("N2");
            var n3 = new Node("N3");

            graph.AddNode(n1);                                      //Add node to graph.
            graph.AddNode(n2);
            graph.AddNode(n3);
            graph.AddEdge(new Edge(n1, n2));                        //Add edge
            graph.AddEdge(new Edge(n2, n3));
            graph.AddEdge(new Edge(n3, n1));

            var g = graph.ToDotStringWithHeader();

            Assert.Equal("digraph g1{\nrankdir=LR;\nN1[label=\" Node1 \";]\nN2[]\nN3[]\nN1->N2[]\nN2->N3[]\nN3->N1[]\n}\n", g);
            var a = 0;
        }

        [Fact]
        public void Example2()
        {
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

            Assert.Equal("digraph g1{\n\nsubgraph cluster_0{\nstyle=filled;color=lightgrey;label=\"process #1\";\na0\na1\na2\na3\na0->a1\na1->a2\na2->a3\n}\n\nsubgraph cluster_1{\ncolor=blue;label=\"process #1\";\nb0\nb1\nb2\nb3\nb0->b1\nb1->b2\nb2->b3\n}\n\nStart[shape=Mdiamond;]\nEnd[shape=Msquare;]\nStart->a0\nStart->b0\na1->b3\nb2->a3\na3->a0\na3->End\nb3->End\n}\n",
                g);
        }
    }
}
