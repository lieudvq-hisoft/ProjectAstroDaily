using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroDailyProject.BE_Bang.Model
{
    public class ChangeModel
    {
        public string userName { get; set; }
        public string otp { get; set; }
        public string password { get; set; }
        public string newPassword { get; set; }
        public string reNewPassword { get; set; }
    }
}
