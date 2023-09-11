/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Quantities;
using ExtensionMethods.Quantities;
using Xunit;
using System.Collections.Generic;

namespace Exercises.Tests.Unit;

public class QuantityTest
{
    [Fact]
    public void EqualityOfLikeUnits()
    {
        Assert.Equal(8.0.Tablespoons(), 8.0.Tablespoons());
        Assert.NotEqual(8.0.Tablespoons(), 6.Tablespoons());
        Assert.NotEqual(8.0.Tablespoons(), new object());
#pragma warning disable xUnit2000
        Assert.NotEqual(8.0.Tablespoons(), null);
#pragma warning restore xUnit2000
    }

    [Fact]
    public void EqualityOfDifferentUnits()
    {
        Assert.Equal(8.0.Tablespoons(), 0.5.Cups());
        Assert.Equal(768.Teaspoons(), 1.Gallons());
        Assert.NotEqual(8.0.Tablespoons(), 8.0.Pints());
        Assert.Equal(1.Miles(), (12 * 5280).Inches());
        Assert.Equal(1.5.Leagues(), 36.Furlongs());
        Assert.Equal(22.Fathoms(), 2.Chains());
    }

    [Fact]
    public void Set()
    {
        Assert.Single(new HashSet<Quantity> { 8.0.Tablespoons(), 8.0.Tablespoons() });
        Assert.Contains(8.0.Tablespoons(), new HashSet<Quantity> { 8.0.Tablespoons() });
    }

    [Fact]
    public void Hash()
    {
        Assert.Equal(8.0.Tablespoons().GetHashCode(), 8.0.Tablespoons().GetHashCode());
        Assert.Equal(8.0.Tablespoons().GetHashCode(), 0.5.Cups().GetHashCode());
    }

    [Fact]
    public void Arithmetic()
    {
        Assert.Equal(0.5.Quarts(), 6.Tablespoons() + 13.Ounces());
        Assert.Equal(-6.Tablespoons(), -6.Tablespoons());
        Assert.Equal(-0.5.Pints(), 10.Tablespoons() - 13.Ounces());
        Assert.Equal(-4.Feet(), 24.Inches() - 2.Yards());
    }
}