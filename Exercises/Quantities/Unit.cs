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

        internal static readonly Unit Celsius = new Unit();
        internal static readonly Unit Fahrenheit = new Unit(5 / 9.0, 32, Celsius);
        internal static readonly Unit GasMark = new Unit(125 / 9.0, -218.0 / 25, Celsius);
        internal static readonly Unit Kelvin = new Unit(1, 273.15, Celsius);
        internal static readonly Unit Rankin = new Unit(5 / 9.0, 491.67, Celsius);

        private readonly Unit _baseUnit;
        private readonly double _baseUnitRatio;
        private readonly double _offset;

        private Unit()
        {
            _baseUnit = this;
            _baseUnitRatio = 1.0;
            _offset = 0.0;
        }

        private Unit(double relativeRatio, Unit relativeUnit): this(relativeRatio, 0.0, relativeUnit) { }

        private Unit(double relativeRatio, double offset, Unit relativeUnit)
        {
            _baseUnit = relativeUnit._baseUnit;
            _baseUnitRatio = relativeRatio * relativeUnit._baseUnitRatio;
            _offset = offset;
        }

        internal double ConvertedAmount(double otherAmount, Unit other)
        {
            if (!this.IsCompatible(other)) throw new ArgumentException("Incompatible Unit types for arithmetic");
            return (otherAmount - other._offset) * other._baseUnitRatio / this._baseUnitRatio + this._offset;
        }

        internal int GetHashCode(double amount) => ((amount - _offset) * _baseUnitRatio).GetHashCode();

        internal bool IsCompatible(Unit other) => this._baseUnit == other._baseUnit;
    }
}

namespace ExtensionMethods.Quantities
{
    public static class QuantityConstructors
    {
        public static RatioQuantity Teaspoons(this double amount) => new RatioQuantity(amount, Unit.Teaspoon);
        public static RatioQuantity Teaspoons(this int amount) => new RatioQuantity(amount, Unit.Teaspoon);
        public static RatioQuantity Tablespoons(this double amount) => new RatioQuantity(amount, Unit.Tablespoon);
        public static RatioQuantity Tablespoons(this int amount) => new RatioQuantity(amount, Unit.Tablespoon);
        public static RatioQuantity Ounces(this double amount) => new RatioQuantity(amount, Unit.Ounce);
        public static RatioQuantity Ounces(this int amount) => new RatioQuantity(amount, Unit.Ounce);
        public static RatioQuantity Cups(this double amount) => new RatioQuantity(amount, Unit.Cup);
        public static RatioQuantity Cups(this int amount) => new RatioQuantity(amount, Unit.Cup);
        public static RatioQuantity Pints(this double amount) => new RatioQuantity(amount, Unit.Pint);
        public static RatioQuantity Pints(this int amount) => new RatioQuantity(amount, Unit.Pint);
        public static RatioQuantity Quarts(this double amount) => new RatioQuantity(amount, Unit.Quart);
        public static RatioQuantity Quarts(this int amount) => new RatioQuantity(amount, Unit.Quart);
        public static RatioQuantity Gallons(this double amount) => new RatioQuantity(amount, Unit.Gallon);
        public static RatioQuantity Gallons(this int amount) => new RatioQuantity(amount, Unit.Gallon);

        public static RatioQuantity Inches(this double amount) => new RatioQuantity(amount, Unit.Inch);
        public static RatioQuantity Inches(this int amount) => new RatioQuantity(amount, Unit.Inch);
        public static RatioQuantity Feet(this double amount) => new RatioQuantity(amount, Unit.Foot);
        public static RatioQuantity Feet(this int amount) => new RatioQuantity(amount, Unit.Foot);
        public static RatioQuantity Yards(this double amount) => new RatioQuantity(amount, Unit.Yard);
        public static RatioQuantity Yards(this int amount) => new RatioQuantity(amount, Unit.Yard);
        public static RatioQuantity Fathoms(this double amount) => new RatioQuantity(amount, Unit.Fathom);
        public static RatioQuantity Fathoms(this int amount) => new RatioQuantity(amount, Unit.Fathom);
        public static RatioQuantity Chains(this double amount) => new RatioQuantity(amount, Unit.Chain);
        public static RatioQuantity Chains(this int amount) => new RatioQuantity(amount, Unit.Chain);
        public static RatioQuantity Furlongs(this double amount) => new RatioQuantity(amount, Unit.Furlong);
        public static RatioQuantity Furlongs(this int amount) => new RatioQuantity(amount, Unit.Furlong);
        public static RatioQuantity Miles(this double amount) => new RatioQuantity(amount, Unit.Mile);
        public static RatioQuantity Miles(this int amount) => new RatioQuantity(amount, Unit.Mile);
        public static RatioQuantity Leagues(this double amount) => new RatioQuantity(amount, Unit.League);
        public static RatioQuantity Leagues(this int amount) => new RatioQuantity(amount, Unit.League);

        public static IntervalQuantity Celsius(this double amount) => new IntervalQuantity(amount, Unit.Celsius);
        public static IntervalQuantity Celsius(this int amount) => new IntervalQuantity(amount, Unit.Celsius);
        public static IntervalQuantity Fahrenheit(this double amount) => new IntervalQuantity(amount, Unit.Fahrenheit);
        public static IntervalQuantity Fahrenheit(this int amount) => new IntervalQuantity(amount, Unit.Fahrenheit);
        public static IntervalQuantity GasMarks(this double amount) => new IntervalQuantity(amount, Unit.GasMark);
        public static IntervalQuantity GasMarks(this int amount) => new IntervalQuantity(amount, Unit.GasMark);
        public static IntervalQuantity Kelvin(this double amount) => new IntervalQuantity(amount, Unit.Kelvin);
        public static IntervalQuantity Kelvin(this int amount) => new IntervalQuantity(amount, Unit.Kelvin);
        public static IntervalQuantity Rankin(this double amount) => new IntervalQuantity(amount, Unit.Rankin);
        public static IntervalQuantity Rankin(this int amount) => new IntervalQuantity(amount, Unit.Rankin);
    }
}