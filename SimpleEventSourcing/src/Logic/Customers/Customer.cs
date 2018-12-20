using System.Collections.Generic;
using System.Linq;

namespace Logic.Customers
{
	public class Customer
	{
		public string Name { get; set; }

		private readonly IList<Address> _addresses = new List<Address>();
		public IReadOnlyList<Address> Addresses => _addresses.ToList();

	}

	public class Address
	{
	}
}
