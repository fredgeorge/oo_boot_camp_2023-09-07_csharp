/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Quantities;

namespace Exercises.Quantities
{

// Understands a specific Metric
    public class Unit
    {
        internal static Unit Teaspoon = new Unit();
        internal static Unit Tablespoon = new Unit(3, Teaspoon);
        internal static Unit Ounce = new Unit(2, Tablespoon);
        internal static Unit Cup = new Unit(8, Ounce);
        internal static Unit Pint = new Unit(2, Cup);
        internal static Unit Quart = new Unit(2, Pint);
        internal static Unit Gallon = new Unit(4, Quart);

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
}

namespace ExtensionMethods.Quantities
{
    public static class QuantityConstructors
    {
        public static Quantity Teaspoons(this double amount) => new Quantity(amount, Unit.Teaspoon);
        public static Quantity Teaspoons(this int amount) => new Quantity(amount, Unit.Teaspoon);
        public static Quantity Tablespoons(this double amount) => new Quantity(amount, Unit.Tablespoon);
        public static Quantity Tablespoons(this int amount) => new Quantity(amount, Unit.Tablespoon);
        public static Quantity Ounces(this double amount) => new Quantity(amount, Unit.Ounce);
        public static Quantity Ounces(this int amount) => new Quantity(amount, Unit.Ounce);
        public static Quantity Cups(this double amount) => new Quantity(amount, Unit.Cup);
        public static Quantity Cups(this int amount) => new Quantity(amount, Unit.Cup);
        public static Quantity Pints(this double amount) => new Quantity(amount, Unit.Pint);
        public static Quantity Pints(this int amount) => new Quantity(amount, Unit.Pint);
        public static Quantity Quarts(this double amount) => new Quantity(amount, Unit.Quart);
        public static Quantity Quarts(this int amount) => new Quantity(amount, Unit.Quart);
        public static Quantity Gallons(this double amount) => new Quantity(amount, Unit.Gallon);
        public static Quantity Gallons(this int amount) => new Quantity(amount, Unit.Gallon);
    }
}