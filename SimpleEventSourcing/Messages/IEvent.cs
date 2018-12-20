using System;

namespace Messages
{
	public interface IEvent
	{
		Guid AggregateId { get; set; }
		string Action { get; set; }
		DateTime When { get; set; }

		string Command { get; set; }
		//string Data { get; set; }
	}
}