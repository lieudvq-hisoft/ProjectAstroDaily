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
    public class AspectTypeController : ControllerBase
    {
        private readonly AstroDailyDBContext _context;

        public AspectTypeController(AstroDailyDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateAspectType(AspectTypeModel aspectTypeModel)
        {
            try
            {
                var aspectType = new AspectType
                {
                    Angle = aspectTypeModel.Angle,
                };
                _context.Add(aspectType);
                _context.SaveChanges(); ;
                return Ok(aspectType);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
