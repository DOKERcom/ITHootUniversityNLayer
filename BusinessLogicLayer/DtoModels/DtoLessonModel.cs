namespace BusinessLogicLayer.DtoModels
{
    public class DtoLessonModel
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }

        public virtual List<DtoUserModel> Users { get; set; }
        public DtoLessonModel()
        {
            Users = new List<DtoUserModel>();
        }
    }
}
