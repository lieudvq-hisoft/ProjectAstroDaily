using System;
using System.Collections.Generic;

#nullable disable

namespace AstroDailyProject.Data
{
    public partial class Aspect
    {
        public Aspect()
        {
            AstroProfiles = new HashSet<AstroProfile>();
            Horoscopes = new HashSet<Horoscope>();
        }

        public int Id { get; set; }
        public int? PlanetId1 { get; set; }
        public int? PlanetId2 { get; set; }
        public int? AspectTypeId { get; set; }

        public virtual AspectType AspectType { get; set; }
        public virtual Planet PlanetId1Navigation { get; set; }
        public virtual Planet PlanetId2Navigation { get; set; }
        public virtual ICollection<AstroProfile> AstroProfiles { get; set; }
        public virtual ICollection<Horoscope> Horoscopes { get; set; }
    }
}
