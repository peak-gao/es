using System;
using Logic.AppServices.Queries;
using Messages.Customers.Commands;
using Messages.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/customers")]
	public sealed class CustomerController : BaseController
	{
		private readonly Logic.Utils.Messages _messages;

		public CustomerController(Logic.Utils.Messages messages)
		{
			_messages = messages;
		}

		[HttpGet]
		public IActionResult GetHistoryList(Guid customerId)
		{
			var list = _messages.Dispatch(new GetHistoryQuery(customerId));
			return Ok(list);
		}

		[HttpPost]
		public IActionResult Add([FromBody] CustomerDto dto)
		{
			var command = new AddCustomerCommand(dto.Name);
			var result = _messages.Dispatch(command);
			return FromResult(result);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid customerId)
		{
			var result = _messages.Dispatch(new DeleteCustomerCommand(customerId));
			return FromResult(result);
		}

		[HttpPut("{id}")]
		public IActionResult Edit(Guid id, [FromBody] CustomerDto dto)
		{
			var command = new UpdateCustomerCommand(dto.Name, id);
			var result = _messages.Dispatch(command);
			return FromResult(result);
		}
	}
}
