using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
	public class Company
	{
		private string _name;
		private decimal _salary;
		private string _department;

		public Company(string name, decimal salary, string department)
		{
			_name = name;
			_salary = salary;
			_department = department;
		}

		public override string ToString()
		{
			return $"{_name} {_department} {_salary:F2}";
		}
	}
}
