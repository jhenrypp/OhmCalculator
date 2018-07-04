using OhmCalculator.Web.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhmCalculator.Web.Models
{
    public class ResistorColors
    {
        public IEnumerable<ColorUIList> BandAList { get; set; }
        public IEnumerable<ColorUIList> BandBList { get; set; }
        public IEnumerable<ColorUIList> BandCList { get; set; }
        public IEnumerable<ColorUIList> BandDList { get; set; }
    }
}
