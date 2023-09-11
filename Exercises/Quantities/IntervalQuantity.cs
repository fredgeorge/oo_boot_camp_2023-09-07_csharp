/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Runtime.CompilerServices;

namespace Exercises.Quantities;

// Undestands a specific Measurement
public class IntervalQuantity
{
    internal const double Epsilon = 1e-9;
    protected readonly double _amount;
    protected readonly Unit _unit;

    public IntervalQuantity(double amount, Unit unit)
    {
        _amount = amount;
        _unit = unit;
    }

    public override bool Equals(object? obj) =>
        this == obj || obj is IntervalQuantity other && this.Equals(other);

    private bool Equals(IntervalQuantity other) => 
        this.IsCompatible(other) && Math.Abs(this._amount - ConvertedAmount(other)) < Epsilon;

    private bool IsCompatible(IntervalQuantity other) => this._unit.IsCompatible(other._unit);

    public override int GetHashCode() => _unit.GetHashCode(_amount);

    protected double ConvertedAmount(IntervalQuantity other) =>
        this._unit.ConvertedAmount(other._amount, other._unit);
}