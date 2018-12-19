using System;

namespace Logic.Dtos
{
    public sealed class ScheduleDto
    {
        public string Action { get; set; }
        public DateTime When { get; set; }
        public Guid ScheduleId { get; set; }
    }
}
