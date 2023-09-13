/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Graph;

// Understands a route from one Node to another Node
public interface Path
{

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
}