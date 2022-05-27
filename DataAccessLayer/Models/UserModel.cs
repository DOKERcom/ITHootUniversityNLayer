using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models
{
    public class UserModel : IdentityUser
    {
        public string RealName { get; set; }
    }
}
