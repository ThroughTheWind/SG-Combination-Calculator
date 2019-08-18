using System;

namespace SGApp
{
    /**
     * <summary>Describes a CombinationValue</summary>
     */
    public class CombinationValue : ICloneable
    {
        /**
         * <summary>Value of the ball</summary>
         */
        public int BallValue { get; set; }
        /**
         * <summary>Number of occurrences of the ball in the current combination</summary>
         */
        public int BallNumber { get; set; }

        /**
         * <summary>Clone method</summary>
         */
        public object Clone()
        {
            return new CombinationValue { BallValue = this.BallValue, BallNumber = this.BallNumber };
        }

        /**
         * <summary>Overrides of ToString</summary>
         */
        public override String ToString()
        {
            return $"Ball value {BallValue}, number of balls {BallNumber}";
        }

        /**
         * <summary>Overrides of Equals</summary>
         */
        public override bool Equals(object obj)
        {
            if(obj.GetType() == typeof(CombinationValue))
            {
                CombinationValue cv = (CombinationValue) obj;
                if(cv.BallNumber.Equals(BallNumber) && cv.BallValue.Equals(BallValue))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
