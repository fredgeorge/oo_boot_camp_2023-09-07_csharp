/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Quantities;
using static Exercises.Quantities.Unit;
using Xunit;

namespace Exercises.Tests.Unit;

public class QuantityTest
{
    [Fact]
    public void EqualityOfLikeUnits()
    {
        Assert.Equal(new Quantity(8.0, Tablespoon), new Quantity(8.0, Tablespoon));
        Assert.NotEqual(new Quantity(8.0, Tablespoon), new Quantity(6.0, Tablespoon));
        Assert.NotEqual(new Quantity(8.0, Tablespoon), new object());
        Assert.NotEqual(new Quantity(8.0, Tablespoon), null);
    }

    [Fact]
    public void EqualityOfDifferentUnits()
    {
        Assert.NotEqual(new Quantity(8.0, Tablespoon), new Quantity(8.0, Pint));
    }
}