using System;
using ConsoleUI.Dtos;

namespace ConsoleUI
{
	class Program
	{
		static void Main()
		{
			ApiClient.Init("http://localhost:52337/api/customers");
			var customer = new CustomerDto { Name = "First Customer", Id = Guid.NewGuid() };
			var result = ApiClient.Add(customer).ConfigureAwait(false).GetAwaiter().GetResult();
			if (result.IsFailure)
			{
				Console.WriteLine("add failure");
			}

			customer.Name = "First Customer update 1";
			result = ApiClient.Update(customer).ConfigureAwait(false).GetAwaiter().GetResult();
			if (result.IsFailure)
			{
				Console.WriteLine("update 1 failure");
			}

			customer.Name = "First Customer update 2";
			result = ApiClient.Update(customer).ConfigureAwait(false).GetAwaiter().GetResult();
			if (result.IsFailure)
			{
				Console.WriteLine("update 2 failure");
			}

			result = ApiClient.Delete(customer.Id).ConfigureAwait(false).GetAwaiter().GetResult();
			if (result.IsFailure)
			{
				Console.WriteLine("delete failure");
			}

			ShowHistory(customer.Id);

			Console.Read();
		}

		private static void ShowHistory(Guid customerId)
		{
			Console.WriteLine("----------------History-----------");
			var customerHistoryDtos = ApiClient.GetHistoryList(customerId).ConfigureAwait(false).GetAwaiter().GetResult();
			foreach (var customerHistoryDto in customerHistoryDtos)
			{
				Console.WriteLine(customerHistoryDto.ToString());
			}
		}
	}
}
