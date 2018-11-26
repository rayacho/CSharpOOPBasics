using System;
using System.Collections.Generic;
using System.Text;

namespace _4.ShoppingSpree
{
	class Person
	{
		private string _name;
		private decimal _money;
		private List<Product> _Products { get; set; }

		public Person()
		{
			_Products = new List<Product>();
		}

		public Person(string name, decimal money):this()
		{
			this.Name = name;
			this.Money = money;
		}

		public string Name
		{
			get { return _name; }
			set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}

				_name = value;
			}
		}

		private decimal Money
		{
			get { return _money; }
			set
			{
				if(value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}

				_money = value;
			}

		}

		public string TryBuyProduct(Product product)
		{
			if (this.Money < product.Price)
			{
				return $"{_name} can't afford {product.Name}";
			}

			this.Money = Money - product.Price;
			_Products.Add(product);

			return $"{_name} bought {product.Name}";
		}

		public override string ToString()
		{
			string productsOutput = _Products.Count > 0 ?
				string.Join(", ", _Products) : "Nothing bought";
			string result = $"{this.Name} - {productsOutput}";
			return result;
		}
	}
}
