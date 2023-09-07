/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System;
using Exercises.Geometry;
using Xunit;

namespace Exercises.Tests.Unit;

// Ensures that Rectangle works correctly
public class RectangleTest
{
    [Fact]
    public void Area()
    {
        Assert.Equal(24.0, new Rectangle(4.0, 6.0).Area());
        Assert.Equal(30.0, new Rectangle(5.0, 6.0).Area());
        Assert.Equal(30, new Rectangle(5, 6).Area());
    }

    [Fact]
    public void Perimeter()
    {
        Assert.Equal(20.0, new Rectangle(4.0, 6.0).Perimeter());
        Assert.Equal(22.0, new Rectangle(5.0, 6.0).Perimeter());
        Assert.Equal(22, new Rectangle(5, 6).Perimeter());
    }

    [Fact]
    public void ValidateParameters()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(0.0, 6.0));
        Assert.Throws<ArgumentException>(() => new Rectangle(4.0, 0.0));
    }
}