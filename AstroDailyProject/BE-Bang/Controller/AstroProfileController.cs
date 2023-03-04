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
    public class AstroProfileController : ControllerBase
    {
        private readonly AstroDailyDBContext _context;

        public AstroProfileController(AstroDailyDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateAstroProfile(AstroProfileModel astroProfileModel)
        {
            try
            {
                var astroProfile = new AstroProfile
                {
                    CustomerId = astroProfileModel.CustomerId,
                    ExplanationId = astroProfileModel.ExplanationId,
                    AspectId = astroProfileModel.AspectId,
                    Comparatible = astroProfileModel.Comparatible
                };
                _context.Add(astroProfile);
                _context.SaveChanges(); ;
                return Ok(astroProfile);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GeAstroProfileById(int id)
        {
            var planets = _context.AstroProfiles.Where(p => p.Id == id);
            if (planets == null)
            {
                return NotFound();
            }
            return Ok(planets);
        }
    }
}
