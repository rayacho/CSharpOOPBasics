using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.CompanyRoster
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Department> departments = new List<Department>();
			int peopleCount = int.Parse(Console.ReadLine());

			for (int person = 0; person < peopleCount; person++)
			{
				string[] emptyInput = Console.ReadLine().Split();
				string departmentName = emptyInput[3];

				if (!departments.Any(d => d.Name == departmentName))
				{
					Department dep = new Department(departmentName);
					departments.Add(dep);
				}

				Department department = departments.FirstOrDefault(d => d.Name == departmentName);
				Employee employee = ParseEmployee(emptyInput);
				department.AddEmployee(employee);
			}

			var maxAverageSalary = departments.OrderByDescending(d => d.AverageSalary).First();

			Console.WriteLine($"Highest Average Salary: {maxAverageSalary.Name}");

			foreach (var emp in maxAverageSalary.Employees.OrderByDescending(e => e.Salary))
			{
				Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
			}
		}

		static Employee ParseEmployee(string[] emptyInput)
		{
			string name = emptyInput[0];
			decimal salary = Decimal.Parse(emptyInput[1]);
			string position = emptyInput[2];
			string email = "n/a";
			int age = -1;

			if (emptyInput.Length == 6)
			{
				email = emptyInput[4];
				age = int.Parse(emptyInput[5]);
			}
			else if (emptyInput.Length == 5)
			{
				bool isAge = int.TryParse(emptyInput[4], out age);

				if (!isAge)
				{
					email = emptyInput[4];
					age = -1;
				}
			}

			Employee employee = new Employee(name, position, salary, age, email);

			return employee;
		}
	}
}
