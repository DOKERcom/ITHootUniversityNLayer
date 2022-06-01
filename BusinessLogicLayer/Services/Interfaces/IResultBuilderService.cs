using ITHootUniversity.Models;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IResultBuilderService
    {
        public ModelForJsonResult ToModelForJsonResult(string resultAction, string resultMessage);
    }
}
