using System;
using System.Collections.Generic;
using System.Linq;

namespace Supplement1_P9
{
    class Program{
        /// <summary>
        /// The main method that runs the console application.
        /// It allows the user to add randomly generated quarters or quit the application.
        /// </summary>
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
                        catch (InvalidSequenceException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message} The invalid number was {enumerator.Current:F3}.");
                        break;
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'A' or 'Q'.");
                }
                }
            }
        }
    }
}