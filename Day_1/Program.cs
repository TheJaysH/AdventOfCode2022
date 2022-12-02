using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Day_1
{
    /// <summary>
    /// https://adventofcode.com/2022/day/1
    /// </summary>
    class Program
    {
        private const string _INPUT_PATH = "input.mcs.txt";

        static void Main(string[] args)
        {
            Part1();            
        }

        public static void Part1()
        {
            var elves = new List<Elf>();
            var fileText = File.ReadAllLines(_INPUT_PATH);

            for (int i = 0; i < fileText.Length; i++)
            {
                var line = fileText[i];

                if (i == 0 || string.IsNullOrEmpty(line))
                {
                    elves.Add(new Elf());
                }

                var elf = elves.LastOrDefault();
                var isNumber = int.TryParse(line, out int calories);

                if (!isNumber)
                    continue;

                elf.TotalCalories += calories;
            }

            var elfWithMostCalories = elves.OrderByDescending(elf => elf.TotalCalories).FirstOrDefault();

            Console.WriteLine($"Answer (Part 1): {elfWithMostCalories.TotalCalories}");

            Part2(elves);
        }

        private static void Part2(List<Elf> elves)
        {
            var top3Elves = elves.OrderByDescending(elf => elf.TotalCalories).SkipLast(elves.Count - 3);
            var totalCalories = top3Elves.Sum(elf => elf.TotalCalories);

            Console.WriteLine($"Answer (Part 2): {totalCalories}");
        }
    }

    class Elf
    {
        public int TotalCalories { get; set; }
    }
}
