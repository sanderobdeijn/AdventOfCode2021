namespace AdventOfCode2021.Day12;

using System;

public class Challenge
{
    public List<Node> Nodes { get; set; }

    public Challenge(string inputFile)
    {
        Nodes = LoadInputs(inputFile);
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    private static List<Node> LoadInputs(string inputFile)
    {
        var nodes = ReadFromFile(inputFile).SelectMany(x => x.Split('-')).Distinct().Select(x => new Node(x)).ToList();
        var values = ReadFromFile(inputFile).Select(x => x.Split('-'));

        foreach (var node in nodes)
        {
            var connectedNodeNames = values.Where(x => x.Contains(node.Name)).Select(x => x.First(x=> x != node.Name)).ToList();
            node.ConnectingNodes = nodes.Where(x => connectedNodeNames.Contains(x.Name)).ToList();  
        }

        return nodes;
    }

    public long FindRoutesWhileVisitingASingleSmallCaveTwice()
    {
        var startNode = Nodes.First(x => x.Type == NodeType.Start);

        var endedRoutes = 0;
        var routes = new List<Route> { new Route(startNode) };

        //for (int i = 0; i < 50000; i++)
        while (routes.Any(x => x.ReachedEnd == false))
        {
            if(!routes.Any(x => x.ReachedEnd == false))
            {
                break;
            }

            var firstNotEndedRoute = routes.Last(x => x.ReachedEnd == false);
            var newRoutes = firstNotEndedRoute.GetNewRoutesWhileVisitingASingleSmallCaveTwice();
            if (newRoutes != null)
            {
                if (newRoutes.Count == 0)
                {
                    routes.Remove(firstNotEndedRoute);
                }
                else
                {
                    routes.Remove(firstNotEndedRoute);

                    routes.AddRange(newRoutes.Except(routes));
                }
            }

            var newEndedRoutes = routes.Where(x=> x.ReachedEnd == true).ToList();
            endedRoutes += newEndedRoutes.Count;

            for (var y = 0; y < newEndedRoutes.Count; y++)
            {
                routes.Remove(newEndedRoutes.ElementAt(y));
            }
        }

        return endedRoutes;
    }

    public List<Route> FindRoutes()
    {
        var startNode = Nodes.First(x => x.Type == NodeType.Start);
        var routes = new List<Route> { new Route(startNode) };

        while(routes.Any(x => x.ReachedEnd == false))
        {
            var firstNotEndedRoute = routes.First(x => x.ReachedEnd == false);
            var newRoutes = firstNotEndedRoute.GetNewRoutes();
            if (newRoutes != null)
            {
                routes.Remove(firstNotEndedRoute);
                routes.AddRange(newRoutes);
            }
        }

        return routes;
    }
}
