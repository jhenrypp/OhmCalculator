using OhmCalculator.ApplicationCore.Entities;
using OhmCalculator.ApplicationCore.Exceptions;
using OhmCalculator.ApplicationCore.interfaces;
using OhmCalculator.ApplicationCore.specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OhmCalculator.ApplicationCore.Services
{
    public class ResistorService: IResistorService
    {
        protected readonly IBandColors colors;
        private string[] bands { get; set; }
        public ResistanceValue ResistanceValue { get; private set; }

        public ResistorService(IBandColors colors)
        {
            this.colors = colors;
        }
        protected void SetColor(Band band, string color)
        {
            if(IsColorValidatedForBand(band, color))
            {
                bands[(int)band] = color;
            }
            else
            {
                throw new ColorNotFoundException(band);
            }
        }
        protected string GetColor(Band band)
        {
            try
            {
                return bands[(int)band];
            }
            catch
            {
                throw new InvalidBandException();
            }
        }
        protected void CreateBand(int numberOfBand)
        {
            if(numberOfBand >=4)
            bands = new string[numberOfBand];
            

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


        public double GetValue(Band band, string color)
        {
            var bandColorValue = new BandColorValue() { Band = band, Color = color };
            var sp = new BandColorSpecification(bandColorValue);
            if(sp.IsSatisfiedBy(bandColorValue))
            {
                var value=colors.GetAllBandColors().Where(sp.ToExpression()).SingleOrDefault();
                if (value == null) throw new ColorNotFoundException(bandColorValue.Band);
                return value.Value;
            }
            return 0;

        }

        public double GetValue(BandColorValue bandColorValue)
        {
            return GetValue(bandColorValue.Band, bandColorValue.Color);
        }

        public bool IsColorValidatedForBand(BandColorValue bandColorValue)
        {
            return IsColorValidatedForBand(bandColorValue.Band, bandColorValue.Color);
        }

        public bool IsColorValidatedForBand(Band band, string color)
        {
            var bandColorValue = new BandColorValue() { Band=band, Color=color };
            var sp = new BandColorSpecification(bandColorValue);
            if (sp.IsSatisfiedBy(bandColorValue))
            {
                var value = colors.GetAllBandColors().Where(sp.ToExpression()).SingleOrDefault();
                return value!=null;
            }
            return false;
        }

        public void SetColors(params string[] colors)
        {
            if (colors.Length == bands.Length)
            {
                char c = 'A';
                for (var i = 0; i < colors.Length; i++)
                {
                    Band band = (Band)Enum.Parse(typeof(Band), $"{int.Parse(c.ToString()) + i}", true);
                    SetColor(band, colors[i]);
                }
                return;
            }

            throw new InvalidBandException("The number of bands and colors are not match.");
        }
    }
}
