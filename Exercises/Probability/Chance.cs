/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Probability;

namespace Exercises.Probability
{

// Understands the likelihood of something specific occurring
    public class Chance
    {
        private const double Epsilon = 1e-9;
        private const double CertainFraction = 1.0;
        private readonly double _fraction;

        internal Chance(double fraction)
        {
            _fraction = fraction;
        }

        public override bool Equals(object? obj) =>
            this == obj || obj is Chance other && this.Equals(other);

        private bool Equals(Chance other) => Math.Abs(this._fraction - other._fraction) < Epsilon;

        public override int GetHashCode() => Math.Round(_fraction/Epsilon).GetHashCode();

        public Chance Not() => new Chance(CertainFraction - this._fraction);

        public static Chance operator !(Chance c) => c.Not();
    }
}

namespace ExtensionMethods.Probability
{
    public static class ChanceConstructors
    {
        public static Chance Chance(this double fraction) => new Chance(fraction);
        public static Chance Chance(this int wholeNumber) => new Chance(wholeNumber);
    }
}