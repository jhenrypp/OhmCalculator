
using OhmCalculator.ApplicationCore.Exceptions;
using OhmCalculator.ApplicationCore.interfaces;
using OhmCalculator.ApplicationCore.specifications;
using OhmCalculator.ApplicationCore.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OhmCalculator.ApplicationCore.Services
{
    public class OhmValueCalculator : IOhmValueCalculator
    {
        
        private readonly IBandColors colors;

        public ResistanceValue ResistanceValue { get; private set; }
        public OhmValueCalculator(IBandColors colors)
        {
            
            this.colors = colors;
        }
        public bool IsColorValidatedForBand(Band band, string color)
        {
            
            return GetValue(band, color)!=null;
        }

        public double? GetValue(Band band, string color)
        {
            var bandColorValue = new BandColorValue() { Band = band, Color = color };
            var sp = new FourBandColorResistorSpecification(bandColorValue);
            if (sp.IsSatisfiedBy(bandColorValue))
            {
                var value = colors.GetAllBandColors().Where(sp.ToExpression()).SingleOrDefault();
                if (value == null) throw new ColorNotFoundException(bandColorValue.Band);
                return value.Value;
            }
            return null;
            
            

        }

        public double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var bandAValue = GetValue(Band.A, bandAColor).Value;
            var bandBValue = GetValue(Band.B, bandBColor).Value;
            var bandCValue = GetValue(Band.C, bandCColor).Value;
            var bandDValue = GetValue(Band.D, bandDColor).Value;

            var result = ((bandAValue * 10) + bandBValue) * bandCValue;
            var variationValue = result * bandDValue;
            ResistanceValue = new ResistanceValue();
            ResistanceValue.Tolorance = $"±{bandDValue}";
            ResistanceValue.Minimum = result - variationValue;
            ResistanceValue.Maximum = result + variationValue;
            return result;
        }
    }
}
