using OhmCalculator.ApplicationCore.Values;
using OhmCalculator.Web.Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhmCalculator.Web.Infrastructures.Interfaces
{
    public interface IBandColorService
    {
         IEnumerable<ColorUIList> GetColor(Band band);
    }
}
