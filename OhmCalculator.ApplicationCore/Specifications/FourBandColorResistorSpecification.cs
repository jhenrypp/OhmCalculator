using OhmCalculator.ApplicationCore.Values;
using OhmCalculator.ApplicationCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OhmCalculator.ApplicationCore.specifications
{
    public sealed class FourBandColorResistorSpecification : BaseSpecification<BandColorValue>
    {
   
        private readonly BandColorValue bandColorValue;

        public FourBandColorResistorSpecification(BandColorValue bandColorValue)
        {
            
            this.bandColorValue = bandColorValue;
        }
        public override Func<BandColorValue, bool> ToExpression()
        {
            
            return b => b.Color.ToLower() == this.bandColorValue.Color.ToLower() && b.Band==bandColorValue.Band;
        }
    }
}
