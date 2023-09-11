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
    public static T Best<T>(this List<T> contestants) where T : Orderable<T> =>
        contestants.Aggregate(contestants.First(), (champion, challenger) => 
            challenger.IsBetterThan(champion) ? challenger : champion);
}