using OhmCalculator.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhmCalculator.ApplicationCore.interfaces
{
    public interface IFourBandResistor:IResistorService
    {
        void SetColors(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }
}
