using CSharpFunctionalExtensions;

namespace Logic.AppServices.Commands
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}