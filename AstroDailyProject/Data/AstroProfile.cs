using System;
using System.Collections.Generic;

#nullable disable

namespace AstroDailyProject.Data
{
    public partial class AstroProfile
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int? ExplanationId { get; set; }
        public int? AspectId { get; set; }
        public int? Comparatible { get; set; }
        public bool? Status { get; set; }

        public virtual Aspect Aspect { get; set; }
        public virtual User Customer { get; set; }
        public virtual Explanation Explanation { get; set; }
    }
}
