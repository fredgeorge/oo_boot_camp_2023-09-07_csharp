/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Probability;
using System.Collections.Generic;
using ExtensionMethods.Probability;
using Xunit;

namespace Exercises.Tests.Unit;

public class ChanceTest
{
    private static readonly Chance Impossible = 0.Chance();
    private static readonly Chance Unlikely = 0.25.Chance();
    private static readonly Chance EquallyLikely = 0.5.Chance();
    private static readonly Chance Likely = 0.75.Chance();
    private static readonly Chance Certain = 1.Chance();

    [Fact]
    public void Equality()
    {
        Assert.Equal(Likely, 0.75.Chance());
        Assert.NotEqual(Likely, Unlikely);
        Assert.NotEqual(Likely, new object());
        Assert.NotEqual(Likely, null);
    }

    [Fact]
    public void Set()
    {
        Assert.Single(new HashSet<Chance> { Likely, 0.75.Chance() });
        Assert.Contains(0.75.Chance(), new HashSet<Chance> { Likely });
    }

    [Fact]
    public void Hash()
    {
        Assert.Equal(0.75.Chance().GetHashCode(), Likely.GetHashCode());
        Assert.Equal(0.3.Chance().GetHashCode(), (!!0.3.Chance()).GetHashCode());
    }

    [Fact]
    public void Not()
    {
        Assert.Equal(Unlikely, !Likely);
        Assert.Equal(Likely, !!Likely);
        Assert.Equal(Likely, Likely.Not().Not());
        Assert.Equal(Impossible, !Certain);
        Assert.Equal(Certain, !Impossible);
        Assert.Equal(0.3.Chance(), !!0.3.Chance());
    }

    [Fact]
    public void And()
    {
        Assert.Equal(Unlikely, EquallyLikely & EquallyLikely);
        Assert.Equal(0.1875.Chance(), Likely & Unlikely);
        Assert.Equal(Unlikely.And(Likely), Likely & Unlikely);
        Assert.Equal(Likely, Likely & Certain);
        Assert.Equal(Impossible, Impossible & Likely);
    }

    [Fact]
    public void Or()
    {
        Assert.Equal(Likely, EquallyLikely | EquallyLikely);
        Assert.Equal(0.8125.Chance(), Likely | Unlikely);
        Assert.Equal(Unlikely.Or(Likely), Likely | Unlikely);
        Assert.Equal(Certain, Likely | Certain);
        Assert.Equal(Likely, Impossible | Likely);
    }
}