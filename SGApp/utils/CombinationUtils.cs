using System;
using System.Collections.Generic;
using System.Text;

namespace SGApp
{
    public class CombinationUtils
    {
        /**
         * <summary>Calculates the highest integer quotient  </summary>
         * <param name="targetValue">Numerator</param>
         * <param name="value">Denominator</param>
         * <returns>Highest integer quotient</returns>
        */
        public static int GetQuotientMax(int targetValue, int value)
        {
            int quotientMax = 0;
            for (var i = 1; i <= targetValue; i++)
            {
                if (value * i >= targetValue)
                {
                    if (value * i == targetValue)
                    {
                        quotientMax = i;
                    }
                    else
                    {
                        quotientMax = i - 1;
                    }
                    break;
                }
            }
            return quotientMax;
        }

        /**
         * <summary>Calculates the value of a combination</summary>
         * <param name="combination">The combination</param>
         * <returns>The current value of the combination</returns>
        */
        public static int GetCombinationValue(Combination combination)
        {
            int value = 0;
            foreach (var combinationEntry in combination)
            {
                value += combinationEntry.BallValue * combinationEntry.BallNumber;
            }
            return value;
        }


    }
}
