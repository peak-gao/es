using System;

namespace Messages.Customers.Events
{
	public class CustomerCreatedEvent : IEvent
	{
		public Guid AggregateId { get; set; }
		public string Action { get; set; }
		public DateTime When { get; set; }
		public string Command { get; set; }
		public string Data { get; set; }
	}
}
