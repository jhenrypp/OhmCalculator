using OhmCalculator.ApplicationCore.interfaces;
using OhmCalculator.ApplicationCore.Values;
using OhmCalculator.Web.Infrastructures.Interfaces;
using OhmCalculator.Web.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhmCalculator.Web.Infrastructures.Services
{
    public class BandColorService : IBandColorService
    {
        private readonly IBandColors bandColor;

        public BandColorService(IBandColors bandColor)
        {
            this.bandColor = bandColor;
        }

        public IEnumerable<ColorUIList> GetColor(Band band)
        {
            return bandColor.GetAllBandColors().Where(x => x.Band == band).Select(x=> new ColorUIList{ Text=x.Color, Value=x.Value.ToString() });
        }
    }
}
