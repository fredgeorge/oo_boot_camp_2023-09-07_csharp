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
        var champion = Unreachable;
        foreach (var neighbor in _neighbors)
        {
            var challenger = neighbor.HopCount(destination, CopyWithThis(visitedNodes));
            if (challenger == Unreachable) continue;
            if (champion == Unreachable || challenger + 1 < champion) champion = challenger + 1;
        }

        return champion;
    }

    private List<Node> NoVisitedNodes() => new();

    private List<Node> CopyWithThis(List<Node> originals) => new(originals) { this };
}