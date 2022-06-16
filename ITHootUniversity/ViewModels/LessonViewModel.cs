namespace ITHootUniversity.ViewModels
{
    public class LessonViewModel
    {
        public string LessonName { get; set; }

        public virtual List<UserViewModel> Users { get; set; }
        public LessonViewModel()
        {
            Users = new List<UserViewModel>();
        }
    }
}
