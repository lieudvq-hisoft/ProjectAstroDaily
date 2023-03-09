using System;
using System.Collections.Generic;

#nullable disable

namespace AstroDailyProject.Data
{
    public partial class Planet
    {
        public Planet()
        {
            AspectPlanetId1Navigations = new HashSet<Aspect>();
            AspectPlanetId2Navigations = new HashSet<Aspect>();
            Explanations = new HashSet<Explanation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Aspect> AspectPlanetId1Navigations { get; set; }
        public virtual ICollection<Aspect> AspectPlanetId2Navigations { get; set; }
        public virtual ICollection<Explanation> Explanations { get; set; }
    }
}
