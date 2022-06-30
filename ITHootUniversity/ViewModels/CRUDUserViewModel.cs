using System.ComponentModel.DataAnnotations;

namespace ITHootUniversity.ViewModels
{
    public class CRUDUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
