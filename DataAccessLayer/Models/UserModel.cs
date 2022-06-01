using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models
{
    public class UserModel : IdentityUser
    {
        public virtual List<LessonModel> Lessons { get; set; }
        public UserModel()
        {
            Lessons = new List<LessonModel>();
        }
    }
}
