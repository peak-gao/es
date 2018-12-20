using System;
using CSharpFunctionalExtensions;
using Logic.AppServices.Commands;

namespace Messages.Customers.Commands
{
	public sealed class UpdateCustomerCommand : ICommand
	{
		public Guid CustomerId { get; }

		public string Name { get; }

		public UpdateCustomerCommand(string name, Guid customerId)
		{
			Name = name;
			CustomerId = customerId;
		}

		internal sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
		{
			public Result Handle(UpdateCustomerCommand command)
			{
				return Result.Ok();
			}
		}
	}
}