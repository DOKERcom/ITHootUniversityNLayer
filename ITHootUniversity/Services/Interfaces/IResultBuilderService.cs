using ITHootUniversity.Models;

namespace ITHootUniversity.Services.Interfaces
{
    public interface IResultBuilderService
    {
        public ModelForJsonResult ToModelForJsonResult(string resultAction, string resultMessage);
    }
}
