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
}
