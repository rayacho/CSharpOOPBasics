using System;
using System.Collections.Generic;
using System.Text;

namespace _4.ShoppingSpree
{
	public class Product
	{
		private string name;
		private decimal price;

		public Product(string productName, decimal productPrice)
		{
			this.Name = productName;
			this.Price = productPrice;
		}

		public string Name
		{
			get { return name; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}

				name = value;
			}
		}

		public decimal Price
		{
			get { return price; }
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}

				price = value;
			}
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
