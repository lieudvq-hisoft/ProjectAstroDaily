using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroDailyProject.BE_Bang.Model
{
    public class HoroscopeModel
    {
        public int Id { get; set; }
        public int? AspectId { get; set; }
        public int? LifeAttributeId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
    }
}
