using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroDailyProject.BE_Bang.Model
{
    public class ExplanationModel
    {
        public int Id { get; set; }
        public int? ZodiacId { get; set; }
        public int? HouseId { get; set; }
        public int? PlanetId { get; set; }
        public string Description { get; set; }
    }
}
