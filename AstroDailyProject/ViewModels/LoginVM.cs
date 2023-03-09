using System.ComponentModel.DataAnnotations;

namespace AstroDailyProject.ViewModels
{
    public class LoginVM
    {
        [Required(AllowEmptyStrings = false)]
        public string IdToken { get; set; }
    }
}
