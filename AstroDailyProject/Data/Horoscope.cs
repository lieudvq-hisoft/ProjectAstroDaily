using System;
using System.Collections.Generic;

#nullable disable

namespace AstroDailyProject.Data
{
    public partial class Horoscope
    {
        public int Id { get; set; }
        public int? AspectId { get; set; }
        public int? LifeAttributeId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }

        public virtual Aspect Aspect { get; set; }
        public virtual LifeAttribute LifeAttribute { get; set; }
    }
}
