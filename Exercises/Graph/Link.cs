/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using static Exercises.Graph.Path;

namespace Exercises.Graph;

// Understands a connection from one Node to another Node
internal class Link
{
    private readonly double _cost;
    private readonly Node _target;

    internal Link(double cost, Node target)
    {
        _cost = cost;
        _target = target;
    }

    internal static double Cost(List<Link> links) => links.Sum(l => l._cost);

    internal Path Path(Node destination, List<Node> visitedNodes, PathStrategy strategy) =>
        _target.Path(destination, visitedNodes, strategy).Prepend(this);
}

public static class LinkExtensions
{
    internal static double Cost(this List<Link> links) => Link.Cost(links);
}