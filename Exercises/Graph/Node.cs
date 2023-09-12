/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Graph;

// Understands its neighbors
public class Node
{
    private const int Unreachable = -1;
    private readonly List<Node> _neighbors = new();
    public Node To(Node neighbor)
    {
        _neighbors.Add(neighbor);
        return neighbor;
    }

    public bool CanReach(Node destination) => HopCount(destination, NoVisitedNodes()) != Unreachable;

    public int HopCount(Node destination)
    {
        var result = HopCount(destination, NoVisitedNodes());
        if (result == Unreachable) throw new ArgumentException("Destination is unreachable");
        return result;
    }

    private int HopCount(Node destination, List<Node> visitedNodes)
    {
        if (this == destination) return 0;
        if (visitedNodes.Contains(this)) return Unreachable;
        visitedNodes.Add(this);
        foreach (var neighbor in _neighbors)
        {
            var neighborHopCount = neighbor.HopCount(destination, visitedNodes);
            if (neighborHopCount != Unreachable) return neighborHopCount + 1;
        }

        return Unreachable;
    }

    private List<Node> NoVisitedNodes() => new();
}