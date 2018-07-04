using OhmCalculator.ApplicationCore.interfaces;
using OhmCalculator.ApplicationCore.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhmCalculator.Web.Infrastructures.Data
{
    public class StubBandColors : IBandColors
    {
        public IEnumerable<BandColorValue> GetAllBandColors()
        {


            var colorList = new List<BandColorValue>();
            
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "Brown", Value = 1 });
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "Red", Value = 2 });
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "Orange", Value = 3 });
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "Yellow", Value = 4 });
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "Green", Value = 5 });
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "Blue", Value = 6 });
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "Violet", Value = 7 });
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "Grey", Value = 8 });
            colorList.Add(new BandColorValue() { Band = Band.A, Color = "White", Value = 9 });

            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Black", Value = 0 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Brown", Value = 1 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Red", Value = 2 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Orange", Value = 3 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Yellow", Value = 4 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Green", Value = 5 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Blue", Value = 6 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Violet", Value = 7 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "Grey", Value = 8 });
            colorList.Add(new BandColorValue() { Band = Band.B, Color = "White", Value = 9 });

            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Pink", Value = 0.001 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Silver", Value = 0.01 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Gold", Value = 0.1 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Black", Value = 1 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Brown", Value = 10 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Red", Value = 100 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Orange", Value  = 1000 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Yellow", Value  = 10000 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Green", Value   = 100000 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Blue", Value    = 1000000 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Violet", Value = 10000000 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "Grey", Value    = 100000000 });
            colorList.Add(new BandColorValue() { Band = Band.C, Color = "White", Value =   1000000000 });


            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Brown", Value = 0.01 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Red", Value = 0.02 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Orange", Value = 0.03 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Yellow", Value = 0.04 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Green", Value = 0.005 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Blue", Value = 0.0025 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Violet", Value = 0.001 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Gray", Value =0.0005 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Silver", Value = 0.1 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "Gold", Value = 0.05 });
            colorList.Add(new BandColorValue() { Band = Band.D, Color = "None", Value = 0.2 });


            return colorList;
        }
    }
}
