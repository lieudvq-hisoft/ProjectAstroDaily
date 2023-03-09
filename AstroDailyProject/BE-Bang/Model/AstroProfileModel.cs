using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroDailyProject.BE_Bang.Model
{
    public class AstroProfileModel
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int? ExplanationId { get; set; }
        public int? AspectId { get; set; }
        public int? Comparatible { get; set; }
        public bool? Status { get; set; }
    }
}
