using System;
using Logic.Dtos;

namespace Logic.AppServices.Events
{
    internal class ScheduleUpdatedEvent
    {
        public DateTime When { get; set; }
        public string Id { get; set; }
        public ScheduleDto Data { get; set; }
    }
}