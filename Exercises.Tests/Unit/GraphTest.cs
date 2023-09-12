/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System;
using System.Xml.Linq;
using Exercises.Graph;
using Xunit;

namespace Exercises.Tests.Unit;
public class GraphTest
{

    private static readonly Node A = new();
    private static readonly Node B = new();
    private static readonly Node C = new();
    private static readonly Node D = new();
    private static readonly Node E = new();
    private static readonly Node F = new();
    private static readonly Node G = new();

    static GraphTest()
    {
        B.To(A);
        B.To(C).To(D).To(E).To(B).To(F);
        C.To(D);
        C.To(E);
    }

    [Fact]
    public void CanReach()
    {
        Assert.True(A.CanReach(A));
        Assert.True(B.CanReach(A));
        Assert.True(B.CanReach(F));
        Assert.True(B.CanReach(D));
        Assert.True(C.CanReach(F));
        Assert.False(A.CanReach(B));
        Assert.False(G.CanReach(B));
        Assert.False(B.CanReach(G));
    }

    [Fact]
    public void HopCount()
    {
        Assert.Equal(0, A.HopCount(A));
        Assert.Equal(1, B.HopCount(A));
        Assert.Equal(1, B.HopCount(F));
        Assert.Equal(2, B.HopCount(D));
        Assert.Equal(3, C.HopCount(F));
        Assert.Throws<ArgumentException>(() => A.HopCount(B));
        Assert.Throws<ArgumentException>(() => G.HopCount(B));
        Assert.Throws<ArgumentException>(() => B.HopCount(G));
    }
}