using AstroDailyProject.BE_Bang.Model;
using AstroDailyProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroDailyProject.BE_Bang.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExplanationController : ControllerBase
    {
        private readonly AstroDailyDBContext _context;

        public ExplanationController(AstroDailyDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateExplanation(ExplanationModel explanationModel)
        {
            try
            {
                var explanation = new Explanation
                {
                    ZodiacId = explanationModel.ZodiacId,
                    HouseId = explanationModel.HouseId,
                    PlanetId = explanationModel.PlanetId,
                    Description = explanationModel.Description
                };
                _context.Add(explanation);
                _context.SaveChanges(); ;
                return Ok(explanation);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var explain = _context.Explanations.ToList();
            return Ok(explain);
        }

    }
}
