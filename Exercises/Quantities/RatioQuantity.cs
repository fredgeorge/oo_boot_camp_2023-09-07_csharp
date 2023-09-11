/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Runtime.CompilerServices;

namespace Exercises.Quantities;

// Undestands a specific Measurement
public class RatioQuantity: IntervalQuantity
{

    public RatioQuantity(double amount, Unit unit): base(amount, unit) { }

    public static RatioQuantity operator +(RatioQuantity q, RatioQuantity other) =>
        new(q._amount + q.ConvertedAmount(other), q._unit);

    public static RatioQuantity operator -(RatioQuantity q) => new RatioQuantity(-q._amount, q._unit);

    public static RatioQuantity operator -(RatioQuantity q, RatioQuantity other) => q + -other;
}