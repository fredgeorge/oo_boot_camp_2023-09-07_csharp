/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using static System.Double;
using static Exercises.Graph.Link;

namespace Exercises.Graph;

// Understands its neighbors
public class Node
{
    private const double Unreachable = PositiveInfinity;
    private readonly List<Link> _links = new();

    public bool CanReach(Node destination) => Cost(destination, NoVisitedNodes(), FewestHops) != Unreachable;

    public int HopCount(Node destination) => (int)Cost(destination, FewestHops);

    public double Cost(Node destination) => Cost(destination, LeastCost);

    public Path Path(Node destination)
    {
        var result = Path(destination, NoVisitedNodes());
        if (result == null) throw new ArgumentException("Destination is unreachable");
        return result;
    }

    internal Path? Path(Node destination, List<Node> visitedNodes)
    {
        if (this == destination) return new Path();
        if (visitedNodes.Contains(this)) return null;
        Path? champion = null;
        foreach (var link in _links)
        {
            var challenger = link.Path(destination, CopyWithThis(visitedNodes));
            if (challenger == null) continue;
            if (champion == null || challenger.Cost() < champion.Cost()) champion = challenger;
        }
        return champion;
    }

    private double Cost(Node destination, CostStrategy strategy)
    {
        var result = Cost(destination, NoVisitedNodes(), strategy);
        if (result == Unreachable) throw new ArgumentException("Destination is unreachable");
        return result;
    }

    internal double Cost(Node destination, List<Node> visitedNodes, CostStrategy strategy)
    {
        if (this == destination) return 0;
        if (visitedNodes.Contains(this) || _links.Count == 0) return Unreachable;
        return _links.Min(link => link.Cost(destination, CopyWithThis(visitedNodes), strategy));
    }

    private List<Node> NoVisitedNodes() => new();

    private List<Node> CopyWithThis(List<Node> originals) => new(originals) { this };

    public LinkBuilder Cost(double amount) => new LinkBuilder(amount, _links);

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