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
    public class LifeAttributeController : ControllerBase
    {
        private readonly AstroDailyDBContext _context;

        public LifeAttributeController(AstroDailyDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateLifeAttribute(LifeAttributeModel lifeAttributeModel)
        {
            try
            {
                var lifeAttribute = new LifeAttribute
                {
                    Spirituality = lifeAttributeModel.Spirituality,
                    Routine = lifeAttributeModel.Routine,
                    SexLove = lifeAttributeModel.SexLove,
                    ThinkingCreativity = lifeAttributeModel.ThinkingCreativity,
                    SocialLife = lifeAttributeModel.SocialLife,
                    Self = lifeAttributeModel.Self
                };
                _context.Add(lifeAttribute);
                _context.SaveChanges(); ;
                return Ok(lifeAttribute);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
