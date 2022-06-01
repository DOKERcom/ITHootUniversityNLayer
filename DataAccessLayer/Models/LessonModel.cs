using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class LessonModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string LessonName { get; set; }

        public virtual List<UserModel> Users { get; set; }
        public LessonModel()
        {
            Users = new List<UserModel>();
        }
    }
}
