using Projects.Base.Enumerations;

namespace Projects.Base.Models.Result
{
    public class ResultMessage
    {
        public ResultMessageType Type { get; set; }
        public string Message { get; set; }

        public ResultMessage(ResultMessageType type, string message)
        {
            Type = type;
            Message = message;
        }
    }

}
