using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OhmCalculator.ApplicationCore.interfaces;
using OhmCalculator.Web.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OhmCalculator.Web.Controllers
{
    [Route("api/[controller]")]
    public class OhmCalculatorController : Controller
    {
        private readonly IOhmValueCalculator calculator;

        public OhmCalculatorController(IOhmValueCalculator calculator)
        {
            this.calculator = calculator;
        }
        // GET: api/<controller>
        [HttpGet("{bandAColor}/{bandBColor}/{bandCColor}/{bandDColor}")]
        public IActionResult Get(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            if(string.IsNullOrEmpty(bandAColor) || string.IsNullOrEmpty(bandBColor) || string.IsNullOrEmpty(bandCColor))
            {
                return BadRequest("All colors must be filled.");
            }
            try
            {
                var result = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);
                return Ok(new ResistantResult(result, calculator.ResistanceValue.Tolorance,
                    calculator.ResistanceValue.Minimum, calculator.ResistanceValue.Maximum));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    
    }
}
