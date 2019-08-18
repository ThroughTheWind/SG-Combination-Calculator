using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace SGApp
{
    /**
     * Generic class calculating possible combinations to reach a target value with an unlimited set of certain items values
     */   
    public class CombinationCalculator : ICombinationCalculator
    {
        private int[] possibleItemsValues;
        private int targetValue;
        private bool calculRealized;
        private List<Combination> combinations;

        public CombinationCalculator(int targetValue, int[] possibleItemsValues)
        {
            TargetValue = targetValue;
            PossibleItemsValues = possibleItemsValues;
        }

        /**
         * Target value
         */
        public int TargetValue {
            get => targetValue;
            set {
                calculRealized = false;
                targetValue = value;
            }
        }

        /**
         * Array of possible items values
         */
        public int[] PossibleItemsValues
        {
            get => possibleItemsValues;
            set
            {
                calculRealized = false;
                possibleItemsValues = value.OrderByDescending(x => x).ToArray();
            }
        }

        /**
         * Number of calculations calculated
         * Returns 0 if the calcul isn't realized
         */
        public int CombinationsCount
        {
            get
            {
                if (!calculRealized) return 0;
                return combinations.Count;
            }
        }
        
        /**
         * Specifies whether the calcul has been realized or not
         */
        public bool IsCalculRealized
        {
            get => calculRealized;
        }

        /**
         * Sets the values of TargetValue and PossibleItemsValues
         * <param name="targetValue">Target value</param>
         * <param name="possibleItemsValues">Possible items values</param>
         */
        public void SetValues(int targetValue, int[] possibleItemsValues)
        {
            TargetValue = targetValue;
            PossibleItemsValues = possibleItemsValues;
        }

        /**
         * Starts the calculation
         */
        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine("You picked the generic way");
            combinations = new List<Combination>();
            Console.WriteLine($"Calculating combinations to find {TargetValue} with {CombinationPrinter.PrintArray<int>(possibleItemsValues)}");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            FindNextCombinations(0, new Combination());
            stopWatch.Stop();
            Console.WriteLine($"Finished calculation in {stopWatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Found {combinations.Count} combinations");
            Console.WriteLine();
        }

        /**
         * Returns the calculations found, forces it if not realized yet
         * <returns>The combinations calculated</returns>
         */
        public Combination[] GetCombinations()
        {
            if (!calculRealized) Start();
            return combinations.ToArray();
        }

        /**
         * Recursive method iterating through PossibleItemsValues to calculate the possible combinations
         * to reach the TargetValue
         * <param name="possibleValueIndex">Index of the PossibleItemsValue array</param>
         * <param name="combination">The current combination</param>
         */
        private void FindNextCombinations(int possibleValueIndex, Combination combination)
        {
            int possibleValue = possibleItemsValues[possibleValueIndex];
            // Calculates the quotient max for (TargetValue - Current combination value) / Possible Item Value
            int maxQuotientValue = CombinationUtils.GetQuotientMax(TargetValue - CombinationUtils.GetCombinationValue(combination), possibleValue);
            // loop from 0 to maxQuotient and calculates the combination value
            for (var i = 0; i <= maxQuotientValue; i++)
            {
                // Clones to get a fresh combination object with precedent values
                Combination newCombination = (Combination) combination.Clone();
                // Adds the current ball value
                newCombination.Add(new CombinationValue() { BallValue = possibleValue, BallNumber = i });
                // Tests the value of the combination
                if(CombinationUtils.GetCombinationValue(newCombination).Equals(TargetValue))
                {
                    // Adds the combination to the list if it equals the target value
                    combinations.Add((Combination)newCombination.Clone());
                } else
                {
                    // If there are values left in the array we call the same function
                    // and process the next possible value
                    if(possibleValueIndex != possibleItemsValues.Length - 1)
                    {
                        FindNextCombinations(possibleValueIndex + 1, newCombination);
                    }
                }
            }
        }
    }
}
