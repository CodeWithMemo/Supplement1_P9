﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Supplement1_P10
{
    class Program{
        static void main{
            List<Quarter> quarters = new List<Quarter>();
            RandomFloatGenerator generator = new RandomFloatGenerator();
            var enumerator = generator.GetEnumerator();
            
                while (true)
            {
                Console.WriteLine("Enter 'A' to add a quarter or 'Q' to quit:");
                string input = Console.ReadLine()?.Trim().ToUpper();
                
                if (input == "Q")
                {
                    Console.WriteLine("Application closed.");
                    break;
                }
                else if (input == "A")
                {
                       try
                    {
                        enumerator.MoveNext();
                        double newValue = enumerator.Current;
                        Quarter newQuarter = new Quarter(newValue);
                        quarters.Add(newQuarter);
                        
                        Console.WriteLine("Current Quarters:");
                        foreach (var group in quarters.GroupBy(q => (int)(q.Value * 4)))
                        {
                            Console.WriteLine(string.Join(", ", group.Select(q => q.Value.ToString("F3"))));
                        }
        }
    }
}