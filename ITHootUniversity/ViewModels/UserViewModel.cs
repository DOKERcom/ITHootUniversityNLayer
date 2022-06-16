namespace ITHootUniversity.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public string Role { get; set; }

        public virtual List<LessonViewModel> Lessons { get; set; }
        public UserViewModel()
        {
            Lessons = new List<LessonViewModel>();
        }
    }
}
