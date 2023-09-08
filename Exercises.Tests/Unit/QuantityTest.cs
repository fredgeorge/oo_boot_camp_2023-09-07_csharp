/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Quantities;
using static Exercises.Quantities.Unit;
using Xunit;
using System.Collections.Generic;

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
        Assert.Equal(new Quantity(8.0, Tablespoon), new Quantity(0.5, Cup));
        Assert.Equal(new Quantity(768, Teaspoon), new Quantity(1, Gallon));
        Assert.NotEqual(new Quantity(8.0, Tablespoon), new Quantity(8.0, Pint));
    }

    [Fact]
    public void Set()
    {
        Assert.Single(new HashSet<Quantity> { new(8.0, Tablespoon), new(8.0, Tablespoon) });
        Assert.Contains(new Quantity(8.0, Tablespoon), new HashSet<Quantity> { new(8.0, Tablespoon) });
    }

    [Fact]
    public void Hash()
    {
        Assert.Equal(new Quantity(8.0, Tablespoon).GetHashCode(), new Quantity(8.0, Tablespoon).GetHashCode());
        Assert.Equal(new Quantity(8.0, Tablespoon).GetHashCode(), new Quantity(0.5, Cup).GetHashCode());
    }
}