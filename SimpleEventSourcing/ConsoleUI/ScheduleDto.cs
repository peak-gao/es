using System;

namespace ConsoleUI
{
    public sealed class ScheduleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Envelope<T>
    {
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime TimeGenerated { get; set; }
    }
}
