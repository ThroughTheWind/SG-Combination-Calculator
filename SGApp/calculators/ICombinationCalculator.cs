namespace SGApp
{
    /**
     * <summary>Interface describing the behavior of a CombinationCalculator</summary>
     */
    public interface ICombinationCalculator
    {
        /**
         * <summary>Returns the possible calculated combinations</summary>
         */
        Combination[] GetCombinations();
    }
}