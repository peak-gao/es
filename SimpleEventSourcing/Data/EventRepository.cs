using System;
using System.Collections.Generic;
using System.Linq;
using Messages;

namespace Data
{
	public static class EventRepository
	{
		public static List<IEvent> Events = new List<IEvent>();

		public static IList<IEvent> GetEvents(Guid aggregateId)
		{
			return Events.Where(e => e.AggregateId.Equals(aggregateId)).ToList();
		}

		public static void AppendEvent(IEvent iEvent)
		{
			Events.Add(iEvent);
		}
	}
}
