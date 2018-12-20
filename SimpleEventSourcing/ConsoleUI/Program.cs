using System;
using ConsoleUI.Dtos;

namespace ConsoleUI
{
	class Program
	{
		static void Main()
		{
			var customer = new CustomerDto { Name = "First Customer", Id = Guid.NewGuid() };
			var result = ApiClient.AddCustomer(customer).ConfigureAwait(false).GetAwaiter().GetResult();
			if (result.IsFailure)
			{
				Console.WriteLine("add failure");
			}

			customer.Name = "First Customer update 1";
			result = ApiClient.UpdateCustomer(customer).ConfigureAwait(false).GetAwaiter().GetResult();
			if (result.IsFailure)
			{
				Console.WriteLine("update 1 failure");
			}

			customer.Name = "First Customer update 2";
			result = ApiClient.UpdateCustomer(customer).ConfigureAwait(false).GetAwaiter().GetResult();
			if (result.IsFailure)
			{
				Console.WriteLine("update 2 failure");
			}

			result = ApiClient.DeleteCustomer(customer.Id).ConfigureAwait(false).GetAwaiter().GetResult();
			if (result.IsFailure)
			{
				Console.WriteLine("delete failure");
			}

			ShowHistory(customer.Id);

			Console.Read();
		}

		private static void ShowHistory(Guid customerId)
		{
			Console.WriteLine(@"----------------Customer:{$customerId} History-----------");
			var customerHistoryDtos = ApiClient.GetHistory(customerId).ConfigureAwait(false).GetAwaiter().GetResult();
			foreach (var customerHistoryDto in customerHistoryDtos)
			{
				Console.WriteLine(customerHistoryDto.ToString());
			}
		}
	}
}
