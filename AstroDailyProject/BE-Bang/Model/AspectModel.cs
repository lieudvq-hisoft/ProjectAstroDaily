using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroDailyProject.BE_Bang.Model
{
    public class AspectModel
    {
        public int Id { get; set; }
        public int? PlanetId1 { get; set; }
        public int? PlanetId2 { get; set; }
        public int? AspectTypeId { get; set; }
    }
}
