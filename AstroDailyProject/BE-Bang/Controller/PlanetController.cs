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
    public class PlanetController : ControllerBase
    {
        private readonly AstroDailyDBContext _context;

        public PlanetController(AstroDailyDBContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public IActionResult CreatePlanet(PlanetModel planetModel)
        {
            try
            {
                var planet = new Planet
                {
                    Name = planetModel.Name,
                    Description = planetModel.Description,
                    Status = 1,
                };
                _context.Add(planet);
                _context.SaveChanges(); ;
                return Ok(planet);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetPlanetById(string name)
        {
            try
            {
                var planets = _context.Planets.Where(p => p.Name.Contains(name) && p.Status == 1).ToList();
                if (planets.Count == 0)
                {
                    return NotFound();
                }
                return Ok(planets);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var planets = _context.Planets.Where(p => p.Status == 1).ToList();
                return Ok(planets);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{name}/delete")]
        public IActionResult DeletePlanet(string name)
        {
            try
            {
                var planet = _context.Planets.SingleOrDefault(lo => lo.Name == name);
                if (name != planet.Name.ToString()) { return BadRequest(); }
                if (planet != null)
                {
                    planet.Status = 0;
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{name}/update")]
        public IActionResult UpdatePlanet(string name,PlanetModel planetModel)
        {
            try
            {
                var planet = _context.Planets.SingleOrDefault(lo => lo.Name == name && lo.Status == 1);
                if (name != planet.Name.ToString()) { return BadRequest(); }
                if (planet != null)
                {
                    planet.Name = planetModel.Name == null ? planet.Name : planetModel.Name;
                    planet.Description = planetModel.Description == null ? planet.Description : planetModel.Description;
                    planet.Status = 1;
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
