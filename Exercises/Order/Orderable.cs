/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Order;

public interface Orderable<in T>
{
    bool IsBetterThan(T other);
}

public static class OrderExtensions
{
    public static T Best<T>(this List<T> contestants) where T : Orderable<T>
    {
        var champion = contestants.First();
        foreach (var challenger in contestants)
            if (challenger.IsBetterThan(champion))
                champion = challenger;
        return champion;
    }
}