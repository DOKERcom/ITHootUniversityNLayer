using ITHootUniversity.Models;
using ITHootUniversity.Services.Interfaces;

namespace ITHootUniversity.Services.Implementations
{
    public class ResultBuilderService : IResultBuilderService
    {
        public ModelForJsonResult ToModelForJsonResult(string resultAction, string resultMessage)
        {
            return new ModelForJsonResult { ResultAction = resultAction, ResultMessage = resultMessage };
        }
    }
}
