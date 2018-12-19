using System;
using CSharpFunctionalExtensions;
using Logic.Schedules;

namespace Logic.AppServices.Commands
{
    public sealed class AddScheduleCommand : ICommand
    {
        public string Name { get; }

        public AddScheduleCommand(string name)
        {
            Name = name;
        }

        internal sealed class RegisterCommandHandler : ICommandHandler<AddScheduleCommand>
        {
            public Result Handle(AddScheduleCommand command)
            {

                return Result.Ok();
            }
        }
    }
}