using System;
using CSharpFunctionalExtensions;
using Logic.AppServices.Commands;

namespace Messages.Customers.Commands
{
	public sealed class DeleteCustomerCommand : ICommand
	{
		public Guid CustomerId { get; }

		public DeleteCustomerCommand(Guid customerId)
		{
			CustomerId = customerId;
		}

		internal sealed class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
		{
			public Result Handle(DeleteCustomerCommand command)
			{
				return Result.Ok();
			}
		}
	}
}