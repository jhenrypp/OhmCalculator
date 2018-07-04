using OhmCalculator.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhmCalculator.ApplicationCore.interfaces
{
    public interface IResistorService
    {
        ResistanceValue ResistanceValue { get; set; }

        double GetValue(Band band, string color);
        bool IsColorValidatedForBand(Band band, string color);
        double CalculateResistance();
        void SetColors(params string[] colors);
    }
}
