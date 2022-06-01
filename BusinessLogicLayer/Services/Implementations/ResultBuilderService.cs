using BusinessLogicLayer.Services.Interfaces;
using ITHootUniversity.Models;

namespace BusinessLogicLayer.Services.Implementations
{
    public class ResultBuilderService : IResultBuilderService
    {
        public ModelForJsonResult ToModelForJsonResult(string resultAction, string resultMessage)
        {
            return new ModelForJsonResult { ResultAction = resultAction, ResultMessage = resultMessage };
        }

    }
}
