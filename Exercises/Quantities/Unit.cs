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
        internal static readonly Unit Teaspoon = new Unit();
        internal static readonly Unit Tablespoon = new Unit(3, Teaspoon);
        internal static readonly Unit Ounce = new Unit(2, Tablespoon);
        internal static readonly Unit Cup = new Unit(8, Ounce);
        internal static readonly Unit Pint = new Unit(2, Cup);
        internal static readonly Unit Quart = new Unit(2, Pint);
        internal static readonly Unit Gallon = new Unit(4, Quart);

        internal static readonly Unit Inch = new Unit();
        internal static readonly Unit Foot = new Unit(12, Inch);
        internal static readonly Unit Yard = new Unit(3, Foot);
        internal static readonly Unit Fathom = new Unit(6, Foot);
        internal static readonly Unit Chain = new Unit(22, Yard);
        internal static readonly Unit Furlong = new Unit(10, Chain);
        internal static readonly Unit Mile = new Unit(8, Furlong);
        internal static readonly Unit League = new Unit(3, Mile);

        private readonly Unit _baseUnit;
        private readonly double _baseUnitRatio;

        private Unit()
        {
            _baseUnit = this;
            _baseUnitRatio = 1.0;
        }

        private Unit(double relativeRatio, Unit relativeUnit)
        {
            _baseUnit = relativeUnit._baseUnit;
            _baseUnitRatio = relativeRatio * relativeUnit._baseUnitRatio;
        }

        internal double ConvertedAmount(double otherAmount, Unit other)
        {
            if (!this.IsCompatible(other)) throw new ArgumentException("Incompatible Unit types for arithmetic");
            return otherAmount * other._baseUnitRatio / this._baseUnitRatio;
        }

        internal int GetHashCode(double amount) => (amount * _baseUnitRatio).GetHashCode();

        public bool IsCompatible(Unit other)
        {
            return this._baseUnit == other._baseUnit;
        }
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

        public static Quantity Inches(this double amount) => new Quantity(amount, Unit.Inch);
        public static Quantity Inches(this int amount) => new Quantity(amount, Unit.Inch);
        public static Quantity Feet(this double amount) => new Quantity(amount, Unit.Foot);
        public static Quantity Feet(this int amount) => new Quantity(amount, Unit.Foot);
        public static Quantity Yards(this double amount) => new Quantity(amount, Unit.Yard);
        public static Quantity Yards(this int amount) => new Quantity(amount, Unit.Yard);
        public static Quantity Fathoms(this double amount) => new Quantity(amount, Unit.Fathom);
        public static Quantity Fathoms(this int amount) => new Quantity(amount, Unit.Fathom);
        public static Quantity Chains(this double amount) => new Quantity(amount, Unit.Chain);
        public static Quantity Chains(this int amount) => new Quantity(amount, Unit.Chain);
        public static Quantity Furlongs(this double amount) => new Quantity(amount, Unit.Furlong);
        public static Quantity Furlongs(this int amount) => new Quantity(amount, Unit.Furlong);
        public static Quantity Miles(this double amount) => new Quantity(amount, Unit.Mile);
        public static Quantity Miles(this int amount) => new Quantity(amount, Unit.Mile);
        public static Quantity Leagues(this double amount) => new Quantity(amount, Unit.League);
        public static Quantity Leagues(this int amount) => new Quantity(amount, Unit.League);

    }
}