using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Logic.Utils;
using Logic.AppServices.Events;
using Messages.Customers.Events;
using Messages.Dtos;
using Newtonsoft.Json;

namespace Logic.AppServices.Queries
{
	public sealed class GetHistoryQuery : IQuery<List<CustomerHistoryDto>>
	{
		private Guid CustomerId { get; }

		public GetHistoryQuery(Guid customerId)
		{
			CustomerId = customerId;
		}

		internal sealed class GetHistoryHandler : IQueryHandler<GetHistoryQuery, List<CustomerHistoryDto>>
		{
			private readonly QueriesConnectionString _connectionString;

			public GetHistoryHandler(QueriesConnectionString connectionString)
			{
				_connectionString = connectionString;
			}

			public List<CustomerHistoryDto> Handle(GetHistoryQuery query)
			{
				var history = new List<CustomerHistoryDto>();
				var events = EventRepository.GetEvents(query.CustomerId);
				foreach (var e in events)
				{
					var customerHistoryDto = new CustomerHistoryDto();
					switch (e.Action)
					{
						case "CustomerCreatedEvent":
							{
								var createdEvent = JsonConvert.DeserializeObject<CustomerCreatedEvent>(e.Command);
								customerHistoryDto.Data = JsonConvert.DeserializeObject<CustomerDto>(createdEvent.Data);
								customerHistoryDto.Action = "created";
								customerHistoryDto.When = createdEvent.When;
								customerHistoryDto.CustomerId = createdEvent.AggregateId;
								break;
							}
						case "CustomerUpdatedEvent":
							{
								var updatedEvent = JsonConvert.DeserializeObject<CustomerUpdatedEvent>(e.Command);
								customerHistoryDto.Data = JsonConvert.DeserializeObject<CustomerDto>(updatedEvent.Data);
								customerHistoryDto.Action = "updated";
								customerHistoryDto.When = updatedEvent.When;
								customerHistoryDto.CustomerId = updatedEvent.AggregateId;
								break;
							}
						case "CustomerDeletedEvent":
							{
								var deletedEvent = JsonConvert.DeserializeObject<CustomerDeletedEvent>(e.Command);
								customerHistoryDto.Data = JsonConvert.DeserializeObject<CustomerDto>(deletedEvent.Data);
								customerHistoryDto.Action = "deleted";
								customerHistoryDto.When = deletedEvent.When;
								customerHistoryDto.CustomerId = deletedEvent.AggregateId;
								break;
							}

						default:
							throw new Exception("Unexpected Case");
					}
					history.Add(customerHistoryDto);
				}
				return history;
			}
		}
	}
}
