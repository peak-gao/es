using System.Collections.Generic;
using System.Linq;
using Logic.Dtos;
using Logic.Schedules;
using Logic.Utils;
using Logic.AppServices.Events;
using Newtonsoft.Json;

namespace Logic.AppServices.Querys
{
	public sealed class GetHistoryQuery : IQuery<List<ScheduleDto>>
	{
		private string ScheduleId { get; }

		public GetHistoryQuery(string scheduleId)
		{
			ScheduleId = scheduleId;
		}

		internal sealed class GetHistoryHandler : IQueryHandler<GetHistoryQuery, List<ScheduleDto>>
		{
			private readonly QueriesConnectionString _connectionString;

			public GetHistoryHandler(QueriesConnectionString connectionString)
			{
				_connectionString = connectionString;
			}

			public List<ScheduleDto> Handle(GetHistoryQuery query)
			{
				var history = new List<ScheduleDto>();
				var events = ScheduleRepository.EventsRepository.Where(a=>a.Id == query.ScheduleId).ToList();
				foreach (var e in events)
				{
					var scheduleDto = new ScheduleDto();
					switch (e.Action)
					{
						case "ScheduleCreatedEvent":
							var createdEvent = JsonConvert.DeserializeObject<ScheduleCreatedEvent>(e.Command);
							scheduleDto = createdEvent.Data;
							scheduleDto.Action = "created";
							scheduleDto.When = createdEvent.When;
							scheduleDto.ScheduleId = createdEvent.Id;
							break;

					case "ScheduleUpdatedEvent":
						var updatedEvent = JsonConvert.DeserializeObject<ScheduleUpdatedEvent>(e.Command);
						scheduleDto = updatedEvent.Data;
						scheduleDto.Action = "updated";
						scheduleDto.When = updatedEvent.When;
						scheduleDto.ScheduleId = updatedEvent.Id;
							break;

						case "ScheduleDeletedEvent":
							var deletedEvent = JsonConvert.DeserializeObject<ScheduleDeletedEvent>(e.Command);
							scheduleDto = deletedEvent.Data;
							scheduleDto.Action = "deleted";
							scheduleDto.When = deletedEvent.When;
							scheduleDto.ScheduleId = deletedEvent.Id;
							break;
					}
					history.Add(scheduleDto);
				}
				return history;
			}
		}
	}
}
