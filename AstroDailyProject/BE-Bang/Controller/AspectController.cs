using AstroDailyProject.BE_Bang.Model;
using AstroDailyProject.Data;
using Microsoft.AspNetCore.Authorization;
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
    
    public class AspectController : ControllerBase
    {
        private readonly AstroDailyDBContext _context;

        public AspectController(AstroDailyDBContext context)
        {
            _context = context;
        }
        //[HttpPost]
        [HttpPost("authenticate")]
        public IActionResult CreateAspect(AspectModel aspectModel)
        {
            try
            {
                var aspect = new Aspect
                {
                    PlanetId1 = aspectModel.PlanetId1,
                    PlanetId2 = aspectModel.PlanetId2,
                    AspectTypeId = aspectModel.AspectTypeId,
                };
                _context.Add(aspect);
                _context.SaveChanges(); ;
                return Ok(aspect);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
