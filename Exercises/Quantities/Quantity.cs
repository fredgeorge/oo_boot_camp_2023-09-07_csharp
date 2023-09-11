/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Runtime.CompilerServices;

namespace Exercises.Quantities;

// Undestands a specific Measurement
public class Quantity
{
    private readonly double _amount;
    private readonly Unit _unit;

    public Quantity(double amount, Unit unit)
    {
        _amount = amount;
        _unit = unit;
    }

    public override bool Equals(object? obj) =>
        this == obj || obj is Quantity other && this.Equals(other);

    private bool Equals(Quantity other) => 
        this.IsCompatible(other) && this._amount == ConvertedAmount(other);

    private bool IsCompatible(Quantity other) => this._unit.IsCompatible(other._unit);

    public override int GetHashCode() => _unit.GetHashCode(_amount);

    private double ConvertedAmount(Quantity other) =>
        this._unit.ConvertedAmount(other._amount, other._unit);

    public static Quantity operator +(Quantity q, Quantity other) =>
        new(q._amount + q.ConvertedAmount(other), q._unit);

    public static Quantity operator -(Quantity q) => new Quantity(-q._amount, q._unit);

    public static Quantity operator -(Quantity q, Quantity other) => q + -other;
}