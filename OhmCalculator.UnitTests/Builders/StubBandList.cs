using OhmCalculator.ApplicationCore.interfaces;
using OhmCalculator.ApplicationCore.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhmCalculator.UnitTests.Builders
{
    public class StubBandList : IBandColors
    {
        public IEnumerable<BandColorValue> GetAllBandColors()
        {
            var colorList = new List<BandColorValue>();
            colorList.Add(new BandColorValue() { Band= Band.A, Color= "Black", Value=0 });
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "Brown", Value = 1 });
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "Red", Value = 2 });

            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Black", Value = 0 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Brown", Value = 1 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Red", Value = 2 });

            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Black", Value = 1 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Brown", Value = 10 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Red", Value = 100 });

            
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Brown", Value = 0.01 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Red", Value = 0.02 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Yellow", Value = 0.05 });

            return colorList;
        }
    }
}
