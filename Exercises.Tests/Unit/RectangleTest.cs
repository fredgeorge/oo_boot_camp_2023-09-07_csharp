/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Geometry;
using Xunit;

namespace Exercises.Tests.Unit;

    // Ensures that Rectangle works correctly
    public class RectangleTest {
            [Fact]
            public void Area() {
                Assert.Equal(24.0, new Rectangle(4.0, 6.0).Area());
            }
        }