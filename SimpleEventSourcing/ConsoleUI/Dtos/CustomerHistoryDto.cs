using System;

namespace ConsoleUI.Dtos
{
	public sealed class CustomerHistoryDto
	{
		public Guid AggregateId { get; set; }
		public string Action { get; set; }
		public DateTime When { get; set; }
		public string Data { get; set; }

		public override string ToString()
		{
			return $"customer: {AggregateId} {Action} {When}";
		}
	}
}