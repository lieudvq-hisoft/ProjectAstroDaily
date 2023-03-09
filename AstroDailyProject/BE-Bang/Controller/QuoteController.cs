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
    public class QuoteController : ControllerBase
    {
        private readonly AstroDailyDBContext _context;

        public QuoteController(AstroDailyDBContext context)
        {
            _context = context;
        }

        [HttpGet("random")]
        public IActionResult GetQuoteRandom()
        {
            var randomRecord = _context.Quotes.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var quote = _context.Quotes.SingleOrDefault(lo => lo.Id == randomRecord.Id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        [HttpPost("create")]
        public IActionResult CreateQuote(QuoteModel quoteModel)
        {
            try
            {
                var newScript = new Quote { Script = quoteModel.Script };
                _context.Add(newScript);
                _context.SaveChanges(); ;
                return Ok(newScript);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditQuote(int id, QuoteModel quoteModel)
        {
            var quote = _context.Quotes.SingleOrDefault(lo => lo.Id == id);
            if (id != quote.Id) { return BadRequest(); }
            if (quote != null)
            {
                quote.Script = quoteModel.Script == null ? quote.Script : quoteModel.Script;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuote(int id)
        {
            var quote = _context.Quotes.SingleOrDefault(lo => lo.Id == id);
            if (quote != null)
            {

                _context.Remove(quote);

                return NoContent();
            }
            else
            {
                return NotFound();
            }


        }
    }
}
