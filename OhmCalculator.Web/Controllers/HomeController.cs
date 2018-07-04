using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OhmCalculator.ApplicationCore.interfaces;
using OhmCalculator.Web.Infrastructures.Interfaces;
using OhmCalculator.Web.Infrastructures.Models;
using OhmCalculator.Web.Models;

namespace OhmCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBandColorService bandColorService;

        public HomeController(IBandColorService bandColorService)
        {
            
            this.bandColorService = bandColorService;
        }
        public IActionResult Index()
        {
            var resistorColors = new ResistorColors();

            resistorColors.BandAList= bandColorService.GetColor(ApplicationCore.Values.Band.A).ToList();
            resistorColors.BandBList=bandColorService.GetColor(ApplicationCore.Values.Band.B).ToList();
            resistorColors.BandCList= bandColorService.GetColor(ApplicationCore.Values.Band.C).ToList();
            resistorColors.BandDList= bandColorService.GetColor(ApplicationCore.Values.Band.D).ToList();

            return View(resistorColors);
        }
    }
}
