/*
 * Copyright (c) 2023 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Runtime.CompilerServices;
using System.Security.Principal;
using Exercises.Order;

namespace Exercises.Geometry;

public class Rectangle : Orderable<Rectangle> {
    private readonly double _length;
    private readonly double _width;

    public Rectangle(double length, double width)
    {
        if (length <= 0.0 || width <= 0.0) throw new ArgumentException("Each dimension must be larger than zero");
        _length = length;
        _width = width;
    }

    public static Rectangle Square(double side) => new(side, side);

    public double Area() => _length * _width;

    public double Perimeter() => 2 * (_width + _length);

    public bool IsBetterThan(Rectangle other) => this.Area() > other.Area();
}