# GraphNet

GraphNet is a small and simple library for creating simple graphs.

The api let's you create objects representing graphs, sub-graphs, nodes and edges in code.
Then the graph can be converted into a file written in the dot-language for further processing with the open source graph visualization software Graphviz. 

Written in c# .net standard. 

Based on:
https://github.com/eternnoir/graphvizapi


# Documentation


# Examples
## How to run:

### From the command line: 

dot.exe -Tpng C:\temp\inputfile.dot -o C:\temp\outfile.png

Dot.exe is the executable for the dot layout engine. Graphviz comes with multiple layout engines. There are executables for other layout engines like neato and twopi. 

The argument -T defines the rendered output format. Graphviz supports a range of formats to render to. Some nice examples are -Tpng for Portable Network Graphics (PNG) image files and -Tpdf for portable document format (PDF). 

See http://www.graphviz.org/doc/info/output.html for the supported output formats. 

### Graphviz GUI: 

Graphviz comes with a simple editor for creating graphs called GVEdit. It is located in the installations bin directory and has the name gvedit.exe. 



# License

MIT License
