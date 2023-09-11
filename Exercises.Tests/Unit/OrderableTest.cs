/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Collections.Generic;
using System;
using Exercises.Geometry;
using Exercises.Order;
using Xunit;
using Exercises.Probability;
using ExtensionMethods.Probability;
using Exercises.Quantities;
using ExtensionMethods.Quantities;

namespace Exercises.Tests.Unit;

public class OrderableTest

{
    [Fact]
    public void LargestRectangle()
    {
        Assert.Equal(24.0, new List<Rectangle>
        {
            new(2, 3),
            new(6.0, 4.0),
            Rectangle.Square(3)
        }.Best().Area());
        Assert.Throws<InvalidOperationException>(() => new List<Rectangle>().Best());
    }

    [Fact]
    public void LeastLikelyChance()
    {
        Assert.Equal(0.1.Chance(), new List<Chance> {
            0.25.Chance(),
            1.Chance(),
            0.1.Chance(),
            0.5.Chance()
        }.Best());
        Assert.Throws<InvalidOperationException>(() => new List<Chance>().Best());
    }

    [Fact]
    public void LargestQuantity()
    {
        Assert.Equal(6.Cups(), new List<RatioQuantity> {
            0.5.Quarts(),
            3.Pints(),
            10.Tablespoons()
        }.Best());
        Assert.Throws<InvalidOperationException>(() => new List<RatioQuantity>().Best());
        Assert.Equal(50.Fahrenheit(), new List<IntervalQuantity> {
            40.Fahrenheit(),
            100.Kelvin(),
            10.Celsius()
        }.Best());
        Assert.Throws<InvalidOperationException>(() => new List<IntervalQuantity>().Best());
    }
}
