using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.CompanyRoster
{
	class Department
	{
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
			get { return _employees; }
			private set { _employees = value; }
		}

		public decimal AverageSalary => this.Employees.Select(e => e.Salary).Average();

		public void AddEmployee(Employee employee)
		{
			this.Employees.Add(employee);
		}
	}
}
