using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SGApp
{
    /// <summary>
    /// Description of SimpleCombinationCalculator.
    /// </summary>
    public class SimpleCombinationCalculator : ICombinationCalculator
    {

        public Combination[] GetCombinations()
        {
            Console.WriteLine();
            Console.WriteLine("You picked the case specific way");
            Console.WriteLine("Calculating combinations to find 1000 with {25|10|5|1}");
            var combinations = new List<SimpleCombination>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // Target value = 1000
            int targetNumber = 1000;
            // Green value = 25
            int maxPossibleGreen = (int)targetNumber / 25;
            // Yellow value = 10
            int maxPossibleYellow = (int)targetNumber / 10;
            // Red value = 5
            int maxPossibleRed = (int)targetNumber / 5;
            // Blue value = 1
            int maxPossibleBlue = targetNumber;

            for (int g = 0; g <= maxPossibleGreen; g++)
            {
                // For each green ball, the number of maxRedBall decrease
                // (2.5 blue balls is equivalent to 1 green ball)
                int currentMaxYellow = maxPossibleYellow - g * 2;
                for (int y = 0; y <= currentMaxYellow; y++)
                {
                    // For each green ball, the number of maxRedBall by 5
                    // (5 red balls is equivalent to 1 green ball)
                    // (2 red balls is equivalent to 1 yellow ball)
                    int currentMaxRed = maxPossibleRed - g * 5 - y * 2; 
                    for (int r = 0; r <= currentMaxRed; r++)
                    {
                        // For each green balls, the number of maxRedBall decrease
                        // (25 blue ball is equivalent to 1 green ball)
                        // (10 blue balls is equivalent to 1 yellow ball)
                        // (5 blue balls is equivalent to 1 red ball)
                        int currentMaxBlue = maxPossibleBlue - g * 25 - y * 10 - r * 5; 
                        for (int b = 0; b <= currentMaxBlue; b++)
                        {
                            if ((g * 25) + (y * 10) + (r * 5) + b == targetNumber)
                            {
                                SimpleCombination sc = new SimpleCombination(g, y, r, b);                                
                                combinations.Add(new SimpleCombination(g, y, r, b));
                            }
                        }
                    }
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Finished calculation in {stopWatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Found {combinations.Count} combinations");
            Console.WriteLine();
            return combinations.ToArray();
        }
    }
}