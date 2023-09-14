/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using static Exercises.Graph.Path;

namespace Exercises.Graph;

// Understands its neighbors
public class Node
{
    private readonly List<Link> _links = new();

    public bool CanReach(Node destination) => Path(destination, NoVisitedNodes(), FewestHops) != None;

    public int HopCount(Node destination) => Path(destination, FewestHops).HopCount();

    public double Cost(Node destination) => Path(destination).Cost();

    public Path Path(Node destination) => Path(destination, LeastCost);

    public List<Path> Paths(Node destination) => Paths(destination, NoVisitedNodes());

    internal List<Path> Paths(Node destination, List<Node> visitedNodes)
    {
        if (this == destination) return new() { new ActualPath() };
        if (visitedNodes.Contains(this)) return new();
        return _links.SelectMany(link => link.Paths(destination, CopyWithThis(visitedNodes))).ToList();
    }

    private Path Path(Node destination, PathStrategy strategy) =>
        Paths(destination).MinBy(p => strategy(p))
        ?? throw new ArgumentException("Destination is unreachable");

    internal Path Path(Node destination, List<Node> visitedNodes, PathStrategy strategy)
    {
        if (this == destination) return new ActualPath();
        if (visitedNodes.Contains(this)) return None;
        return _links
            .Select(link => link.Path(destination, CopyWithThis(visitedNodes), strategy))
            .MinBy(p => strategy(p)) ?? None;
    }

    private List<Node> NoVisitedNodes() => new();

    private List<Node> CopyWithThis(List<Node> originals) => new(originals) { this };

    public LinkBuilder Cost(double amount) => new(amount, _links);

    public class LinkBuilder
    {
        private readonly double _cost;
        private readonly List<Link> _links;

        internal LinkBuilder(double cost, List<Link> links)
        {
            _cost = cost;
            _links = links;
        }

        public Node To(Node neighbor)
        {
            _links.Add(new Link(_cost, neighbor));
            return neighbor;
        }
    }
}