/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

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
        this._amount == other._amount && this._unit == other._unit;

    public override int GetHashCode() => 
        _amount.GetHashCode() * 37 + _unit.GetHashCode();
}