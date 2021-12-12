namespace AdventOfCode2021.Day12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Route
{
    public List<Node> NodeList { get; private set; }

    public Route(Node startNode)
    {
        NodeList = new List<Node> { startNode };
    }

    public Route(List<Node> nodes)
    {
        NodeList = nodes;
    }

    public bool ReachedEnd => NodeList.Last().Type == NodeType.End;

    public List<Route>? GetNewRoutes()
    {
        var lastNode = NodeList.Last();
        if(lastNode.Type == NodeType.End)
        {
            return null;
        }

        var newRoutes = new List<Route>();

        foreach (var ConnectingNode in lastNode.ConnectingNodes)
        {
            newRoutes.Add(new Route(new List<Node>(NodeList) { ConnectingNode }));
        }

        return newRoutes.Where(x => x.IsValidRoute()).ToList();
    }

    private bool IsValidRoute()
    {
        return !NodeList.GroupBy(x => x).Any(x => x.Count() > 1 && x.Key.Type != NodeType.Big);
    }

    internal List<Route>? GetNewRoutesWhileVisitingASingleSmallCaveTwice()
    {
        var lastNode = NodeList.Last();
        if (lastNode.Type == NodeType.End)
        {
            return null;
        }

        var newRoutes = new List<Route>();

        foreach (var ConnectingNode in lastNode.ConnectingNodes)
        {
            newRoutes.Add(new Route(new List<Node>(NodeList) { ConnectingNode }));
        }

        return newRoutes.Where(x => x.IsValidRouteWhenAllowingASingleSmallCaveToBeVisitedTwice()).ToList();
    }

    private bool IsValidRouteWhenAllowingASingleSmallCaveToBeVisitedTwice()
    {
        var groupedNodes = NodeList.GroupBy(x => x).Where(x => x.Count() > 1 && x.Key.Type != NodeType.Big).ToList();

        return groupedNodes.All(x => x.Key.Type == NodeType.Small && x.Count() == 2) && groupedNodes.Count <= 1;
    }
}
