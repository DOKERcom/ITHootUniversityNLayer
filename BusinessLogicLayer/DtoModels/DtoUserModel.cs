namespace BusinessLogicLayer.DtoModels
{
    public class DtoUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual List<DtoLessonModel> Lessons { get; set; }
        public DtoUserModel()
        {
            Lessons = new List<DtoLessonModel>();
        }
    }
}
