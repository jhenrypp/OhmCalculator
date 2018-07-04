using OhmCalculator.ApplicationCore.Entities;
using OhmCalculator.ApplicationCore.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhmCalculator.ApplicationCore.Services
{
    public class FourBandResistor:ResistorService, IFourBandResistor
    {
        
        public BandColorValue BandColorValue { get; set; }
        public ResistanceValue ResistanceValue { get; set; }

        public FourBandResistor(IBandColors colors):base(colors)
        {
            //Create 4 color bands 
            base.CreateBand(4);
            ResistanceValue = new ResistanceValue();
        }

        public void SetColors(string bandAColor, string bandBColor, string bandCColor, string bandDColor) {

            SetColor(Band.A, bandAColor);
            SetColor(Band.B, bandBColor);
            SetColor(Band.C, bandCColor);
            SetColor(Band.D, bandDColor);
        }

        public override double CalculateResistance()
        {
            
            var bandAValue = GetValue(Band.A, GetColor(Band.A));
            var bandBValue = GetValue(Band.B, GetColor(Band.B));
            var bandCValue = GetValue(Band.C, GetColor(Band.C));
            var bandDValue = GetValue(Band.D, GetColor(Band.D));

            var result = ((bandAValue * 10) + bandBValue) * bandCValue;
            var variationValue = result * bandDValue;
            ResistanceValue.Tolorance = $"±{bandDValue}";
            ResistanceValue.Minimum = result - variationValue;
            ResistanceValue.Maximum = result + variationValue;
            return result;
        }

     
    }
}
