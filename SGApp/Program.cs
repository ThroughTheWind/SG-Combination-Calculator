
using System;

namespace SGApp
{
    class Program
    {
        // Default values used for the exercise
        private static int[] possibleItemsValues = new int[] { 1, 5, 10, 25 };
        private static int targetValue = 1000;

        private static void PrintSubject()
        {
            Console.WriteLine("--------------------------------------- SG Test Exercise ---------------------------------------");
            Console.WriteLine("Evaluator : CONTI Morgan");
            Console.WriteLine("Author    : DANCRE Antoine");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("Subject   :");
            Console.WriteLine("You have 4 possible colours of balls, each having a different value:");
            Console.WriteLine("  - Green   25 points");
            Console.WriteLine("  - Yellow  10 points");
            Console.WriteLine("  - Red     5 points");
            Console.WriteLine("  - Blue    1 point");
            Console.WriteLine();
            Console.WriteLine("There is, for example, 6 different ways of getting 15 points:");
            Console.WriteLine("  - 1 yellow and 1 red");
            Console.WriteLine("  - 1 yellow and 5 blue");
            Console.WriteLine("  - 3 red");
            Console.WriteLine("  - 2 red and 5 blue");
            Console.WriteLine("  - 1 red and 10 blue");
            Console.WriteLine("  - 15 blue");
            Console.WriteLine();
            Console.WriteLine("How many different ways is there to obtain 1,000 points?");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
        }

        private static void PrintHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Two ways to calculate the result have been implemented");
            Console.WriteLine("  • (1) A generic class taking the target value and the possible items values as parameters");
            Console.WriteLine("  • (2) A case specific class resolving only the current problem");
            Console.WriteLine();
            Console.WriteLine("Which way would you like to use ?");
            Console.WriteLine("Type (1) for the generic way and (2) for the specific one");
            Console.WriteLine("Type 'q' to exit the program");
            Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            PrintSubject();
            PrintHeader();
            var inputStr = Console.ReadLine();
            while(!inputStr.ToLower().Equals("q"))
            {
                if(inputStr.Equals("1"))
                {
                    CombinationCalculator cc = new CombinationCalculator(targetValue, possibleItemsValues);
                    cc.GetCombinations();
                    PrintHeader();
                } else if(inputStr.Equals("2"))
                {
                    SimpleCombinationCalculator scc = new SimpleCombinationCalculator();
                    scc.GetCombinations();
                    PrintHeader();
                }
                inputStr = Console.ReadLine();
            }
        }
    }
}
