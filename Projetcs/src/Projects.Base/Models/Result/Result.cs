using Projects.Base.Enumerations;

namespace Projects.Base.Models.Result
{
    public class Result
    {
        public bool Success => Messages.Where(x => x.Type == ResultMessageType.Error).Count() == 0;
        public List<ResultMessage> Messages { get; set; } = new();

        public Result() {}

        public void AddError(string message) => Messages.Add(new ResultMessage(ResultMessageType.Error, message));
        public void AddInfo(string message) => Messages.Add(new ResultMessage(ResultMessageType.Info, message));
    }

}
