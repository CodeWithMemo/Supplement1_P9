﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Supplement1_P9;

/// <summary>
/// Represents an error that occurs when a sequence of numbers does 
/// not meet the expected pattern.
/// </summary>
public class InvalidSequenceException : Exception
{
    public InvalidSequenceException(string message) : base(message) { }
}

/// <summary>
/// Generates an infinite sequence of random floating-point numbers
/// between 0.0 and 1.0.
/// </summary>
public class RandomFloatGenerator : IEnumerable<double>
{
    private Random _random = new Random();

/// <summary>
/// Returns an enumerator that generates an infinite sequence of
/// random floating-point numbers between 0.0 and 1.0.
/// </summary>
/// <returns>An enumerator that iterates through the random
/// floating-point numbers in the sequence.</returns>
/// <exception cref="InvalidSequenceException">Thrown when three
/// consecutive random numbers are less than or equal to 0.5.</exception>
    public IEnumerator<double> GetEnumerator()
    {
        int count = 0;
        while (true)
        {
            double number = _random.NextDouble();
            yield return number;

            if (number <= 0.5)
                count++;
            else
                count = 0;

            if (count >= 3)
                throw new InvalidSequenceException("Three consecutive numbers were ≤ 0.5.");
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

/// <summary>
/// Represents a quarter of a unit, with a value between 0.0 and 1.0,
/// inclusive of 0.0 but exclusive of 1.0.
/// </summary>
public class Quarter
{
    public double Value { get; }

    public Quarter(double value)
    {
        if (value < 0.0 || value >= 1.0)
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0.0 and 1.0");
        Value = value;
    }

    private int GetQuarter() => (int)(Value * 4);

    public static bool operator ==(Quarter q1, Quarter q2) => q1.GetQuarter() == q2.GetQuarter();
    public static bool operator !=(Quarter q1, Quarter q2) => !(q1 == q2);
    public static bool operator <(Quarter q1, Quarter q2) => q1.Value < q2.Value;
    public static bool operator >(Quarter q1, Quarter q2) => q1.Value > q2.Value;
    public static bool operator <=(Quarter q1, Quarter q2) => q1.Value <= q2.Value;
    public static bool operator >=(Quarter q1, Quarter q2) => q1.Value >= q2.Value;
    
    public override bool Equals(object obj) => obj is Quarter other && this == other;
    public override int GetHashCode() => GetQuarter().GetHashCode();
}