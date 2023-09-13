/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using static System.Double;

namespace Exercises.Graph;

// Understands its neighbors
public class Node
{
    private const double Unreachable = PositiveInfinity;
    private readonly List<Link> _links = new();

    public Node To(Node neighbor)
    {
        _links.Add(new Link(neighbor));
        return neighbor;
    }

    public bool CanReach(Node destination) => HopCount(destination, NoVisitedNodes()) != Unreachable;

    public int HopCount(Node destination)
    {
        var result = HopCount(destination, NoVisitedNodes());
        if (result == Unreachable) throw new ArgumentException("Destination is unreachable");
        return (int)result;
    }

    internal double HopCount(Node destination, List<Node> visitedNodes)
    {
        if (this == destination) return 0;
        if (visitedNodes.Contains(this) || _links.Count == 0) return Unreachable;
        return _links.Min(link => link.HopCount(destination, CopyWithThis(visitedNodes)));
    }

    private List<Node> NoVisitedNodes() => new();

    private List<Node> CopyWithThis(List<Node> originals) => new(originals) { this };
}