using OhmCalculator.ApplicationCore.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhmCalculator.ApplicationCore.interfaces
{
    public interface IBandColors
    {
        /// <summary>
        /// Return all colors that assign to each bands.
        /// </summary>
        /// <returns></returns>
        IEnumerable<BandColorValue> GetAllBandColors();

    }
}
