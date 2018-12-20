using System;

namespace Messages.Dtos
{
	public sealed class CustomerHistoryDto
	{
		public Guid CustomerId { get; set; }
		public string Action { get; set; }
		public DateTime When { get; set; }
		public CustomerDto Data { get; set; }
	}
}