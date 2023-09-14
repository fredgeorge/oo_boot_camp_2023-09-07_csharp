/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */


namespace Exercises.Graph;

// Understands a route from one Node to another Node
public class Path
{
    private readonly Node _destination;

    internal delegate double PathStrategy(Path p);

    internal static PathStrategy LeastCost = p => p.Cost();
    internal static PathStrategy FewestHops = p => p.HopCount();

    internal static List<Path> FilterByDestination(List<Path> paths, Node destination) =>
        paths.FindAll(p => p._destination == destination);

    internal Path(Node destination)
    {
        _destination = destination;
    }

    private readonly List<Link> _links = new();

    public double Cost() => _links.Cost();

    public int HopCount() => _links.Count;

    internal Path Prepend(Link link)
    {
        _links.Add(link);
        return this;
    }
}

internal static class PathExtensions
{
    internal static List<Path> FilterByDestination(this List<Path> paths, Node destination) =>
    Path.FilterByDestination(paths, destination);
}