using HomeEnglish.Shared.Commands;

namespace HomeEnglish.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}