namespace AdventOfCode2021.Day12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node
{
    public Node(string name, List<Node> connectingNodes)
    {
        Name = name;
        ConnectingNodes = connectingNodes;
        Type = ParseType(name);

    }

    private static NodeType ParseType(string name)
    {
        if(name == "start")
        {
            return NodeType.Start;
        }
        if (name == "end")
        {
            return NodeType.End;
        }
        if (char.IsUpper(name.First()))
        {
            return NodeType.Big;
        }
        if (char.IsLower(name.First()))
        {
            return NodeType.Small;
        }

        throw new InvalidOperationException();
    }

    public Node(string name)
    {
        Name = name;
        ConnectingNodes = new List<Node>();
        Type = ParseType(name);
    }

    public string Name { get; set; }

    public List<Node> ConnectingNodes { get; set; }
    
    public NodeType Type { get; set; }
}
