using System;
using System.Collections.Generic;

#nullable disable

namespace AstroDailyProject.Data
{
    public partial class Explanation
    {
        public Explanation()
        {
            AstroProfiles = new HashSet<AstroProfile>();
        }

        public int Id { get; set; }
        public int? ZodiacId { get; set; }
        public int? HouseId { get; set; }
        public int? PlanetId { get; set; }
        public string Description { get; set; }

        public virtual House House { get; set; }
        public virtual Planet Planet { get; set; }
        public virtual Zodiac Zodiac { get; set; }
        public virtual ICollection<AstroProfile> AstroProfiles { get; set; }
    }
}
