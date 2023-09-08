/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Quantities;

// Understands a specific Metric
public class Unit
{
    public static Unit Teaspoon = new Unit();
    public static Unit Tablespoon = new Unit(3, Teaspoon);
    public static Unit Ounce = new Unit(2, Tablespoon);
    public static Unit Cup = new Unit(8, Ounce);
    public static Unit Pint = new Unit(2, Cup);
    public static Unit Quart = new Unit(2, Pint);
    public static Unit Gallon = new Unit(4, Quart);

    private readonly double _baseUnitRatio;

    private Unit()
    {
        _baseUnitRatio = 1.0;
    }

    private Unit(double relativeRatio, Unit relativeUnit)
    {
        _baseUnitRatio = relativeRatio * relativeUnit._baseUnitRatio;
    }

    internal double ConvertedAmount(double otherAmount, Unit other) => 
        otherAmount * other._baseUnitRatio / this._baseUnitRatio;

    internal int GetHashCode(double amount) => (amount * _baseUnitRatio).GetHashCode();
}