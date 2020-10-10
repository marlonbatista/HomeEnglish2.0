using HomeEnglish.Shared.Commands;

namespace HomeEnglish.Domain.DomainContext.Commands.Outputs
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool sucess, string message, object data)
        {
            Success = sucess;
            Message = message;
            Data = data;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}