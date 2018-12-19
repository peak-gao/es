using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Schedules
{
	public class Schedule
	{
		public string Name { get; set; }

		private readonly IList<ScheduleDetail> _scheduleDetails = new List<ScheduleDetail>();
		public IReadOnlyList<ScheduleDetail> ScheduleDetails => _scheduleDetails.ToList();

	}

	public class ScheduleDetail
	{
	}
}
