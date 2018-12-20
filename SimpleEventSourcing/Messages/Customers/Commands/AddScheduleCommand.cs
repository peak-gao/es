using CSharpFunctionalExtensions;
using Logic.AppServices.Commands;
using Messages.Dtos;

namespace Messages.Customers.Commands
{
	public sealed class AddCustomerCommand : ICommand
	{
		public string Name { get; }

		public AddCustomerCommand(string name)
		{
			Name = name;
		}

		internal sealed class AddCustomerCommandHandler : ICommandHandler<AddCustomerCommand>
		{
			public Result Handle(AddCustomerCommand command)
			{
				return Result.Ok();
			}
		}
	}
}