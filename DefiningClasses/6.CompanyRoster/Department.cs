using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.CompanyRoster
{
	class Department
	{
		//TODO: VARIABLES WITH _, CHECK EVERY CONSTRUCTOR WITH NULLREFERENCE
		private List<Employee> _employees;
		string _name;

		public Department(string name)
		{
			Employees = new List<Employee>();
			Name = name;
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public List<Employee> Employees
		{
			get
			{
				return _employees;
			}
			private set
			{
				_employees = value;
			}
		}

		public decimal AverageSalary => Employees.Select(e => e.Salary).Average();

		public void AddEmployee(Employee employee)
		{
			if (employee == null)
			{
				throw new ArgumentNullException();
			}

			Employees.Add(employee);
		}
	}
}
