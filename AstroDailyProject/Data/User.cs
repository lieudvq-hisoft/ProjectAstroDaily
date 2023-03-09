using System;
using System.Collections.Generic;

#nullable disable

namespace AstroDailyProject.Data
{
    public partial class User
    {
        public User()
        {
            AstroProfiles = new HashSet<AstroProfile>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Otp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte? DobDay { get; set; }
        public byte? DobMonth { get; set; }
        public short? DobYear { get; set; }
        public string BirthPlace { get; set; }
        public TimeSpan? BirthTime { get; set; }
        public bool? Status { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<AstroProfile> AstroProfiles { get; set; }
    }
}
