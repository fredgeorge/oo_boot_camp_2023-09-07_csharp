/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Graph;

// Understands its neighbors
public class Node
{
    private readonly List<Node> _neighbors = new();
    public Node To(Node neighbor)
    {
        _neighbors.Add(neighbor);
        return neighbor;
    }

    public bool CanReach(Node destination) => CanReach(destination, NoVisitedNodes());

    private bool CanReach(Node destination, List<Node> visitedNodes)
    {
        if (this == destination) return true;
        if (visitedNodes.Contains(this)) return false;
        visitedNodes.Add(this);
        return _neighbors.Any(n=>n.CanReach(destination, visitedNodes));
    }

    private List<Node> NoVisitedNodes() => new();
}