
namespace SGApp
{
    /**
     * Simple combination class
     * Used by the SimpleCombinationCalculator
     * Describes only the test case of the exercise
     */
    public class SimpleCombination : Combination
    {
        /**
         * Constructor
         * <param name="green">Number of occurrences of the green ball</param>
         * <param name="yellow">Number of occurrences of the yellow ball</param>
         * <param name="red">Number of occurrences of the red ball</param>
         * <param name="blue">Number of occurrences of the blue ball</param>
         */
        public SimpleCombination(int green, int yellow, int red, int blue)
        {
            Add(new CombinationValue() { BallNumber = 25, BallValue = green });
            Add(new CombinationValue() { BallNumber = 10, BallValue = yellow });
            Add(new CombinationValue() { BallNumber = 5, BallValue = red });
            Add(new CombinationValue() { BallNumber = 1, BallValue = blue });
        }
        
    }
}
