/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using static System.Double;

namespace Exercises.Graph;

// Understands a route from one Node to another Node
public interface Path
{
    internal delegate double PathStrategy(Path p);

    internal static PathStrategy LeastCost = p => p.Cost();
    internal static PathStrategy FewestHops = p => p.HopCount();

    internal static Path None = new NoPath();
    public double Cost();
    public int HopCount();
    internal Path Prepend(Link link);

    internal class ActualPath: Path
    {
        private readonly List<Link> _links = new();
        internal ActualPath() { }

        public double Cost() => _links.Cost();

        public int HopCount() => _links.Count;

        Path Path.Prepend(Link link)
        {
            _links.Add(link);
            return this;
        }
    }

    private class NoPath : Path
    {
        public double Cost() => PositiveInfinity;

        public int HopCount() => Int32.MaxValue;

        Path Path.Prepend(Link link) => this;
    }
}