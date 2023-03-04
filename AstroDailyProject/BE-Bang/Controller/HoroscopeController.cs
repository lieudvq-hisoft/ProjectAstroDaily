using AstroDailyProject.BE_Bang.Model;
using AstroDailyProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AstroDailyProject.BE_Bang.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoroscopeController : ControllerBase
    {
        private readonly AstroDailyDBContext _context;

        public HoroscopeController(AstroDailyDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateHoroscope(HoroscopeModel horoscopeModel)
        {
            try
            {
                var horoscope = new Horoscope
                {
                    AspectId = horoscopeModel.AspectId,
                    LifeAttributeId = horoscopeModel.LifeAttributeId,
                    Date = horoscopeModel.Date,
                    Description = horoscopeModel.Description
                };
                _context.Add(horoscope);
                _context.SaveChanges(); ;
                return Ok(horoscope);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> PostParis(string name, DateTime date, TimeSpan time, long place_id)
        {
            string dateTime = date.ToString("yyyy-MM-dd");

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri("https://api.bloom.be/api/natal"),
                        Content = new StringContent($"{{\"name\":\"{name}\", \"date\":\"{dateTime}\", \"time\":\"{time:hh\\:mm}\", \"place_id\":{place_id}, \"lang\":\"en\", \"system\":\"p\", \"planets\":[0,1,2,3,4,5,6,7,8,9], \"collect_text\":true}}", Encoding.UTF8, "application/json")
                    };
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "1138721|8C4xbp9TU3Eg6KCltFt7yZwOUGuuZtxGxrWd7GNN");

                    using (var response = await httpClient.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();

                            return Ok(content);
                        }
                        else
                        {
                            return BadRequest(response.ReasonPhrase);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
