using System;
using System.Collections.Generic;
using System.Linq;

namespace SGApp
{
    /**
     * <summary>Class describing a combination</summary>
     */
    public class Combination : List<CombinationValue>, ICloneable
    {
        public Combination() : base()            
        {

        }

        /**
         * <summary>Clone method</summary>
         */
        public object Clone()
        {
            var clonedValue = new Combination();
            clonedValue.AddRange(this.Select(x => (CombinationValue)x.Clone()));
            return clonedValue;
        }

        /**
         * <summary>Overrides of Equals</summary>
         */
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Combination) || obj.GetType().BaseType == typeof(Combination))
            {
                Combination testedCombination = (Combination) obj;
                if (this.Count == testedCombination.Count)
                {
                    if(this.Where(x => !testedCombination.Contains(x)).Count() == 0)
                    {
                        return true;
                    }
                }
            }
            return true;
        }

    }
}
