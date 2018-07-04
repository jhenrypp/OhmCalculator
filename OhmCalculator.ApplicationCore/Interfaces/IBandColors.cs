using OhmCalculator.ApplicationCore.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhmCalculator.ApplicationCore.interfaces
{
    public interface IBandColors
    {
        IEnumerable<BandColorValue> GetAllBandColors();

    }
}
