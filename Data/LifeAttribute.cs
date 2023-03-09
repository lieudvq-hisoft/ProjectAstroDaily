using System;
using System.Collections.Generic;

#nullable disable

namespace AstroDailyProject.Data
{
    public partial class LifeAttribute
    {
        public LifeAttribute()
        {
            Horoscopes = new HashSet<Horoscope>();
        }

        public int Id { get; set; }
        public string Spirituality { get; set; }
        public string Routine { get; set; }
        public string SexLove { get; set; }
        public string ThinkingCreativity { get; set; }
        public string SocialLife { get; set; }
        public string Self { get; set; }

        public virtual ICollection<Horoscope> Horoscopes { get; set; }
    }
}
