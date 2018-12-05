using System;
using System.Text;

namespace _3.Mankind
{
	public class Worker : Human
	{
		private const decimal MinWeekSalary = 10;
		private const int MinWorkingHoursPerDay = 1;
		private const int MaxWorkingHoursPerDay = 12;
		private decimal weekSalary;
		private double workHoursPerDay;

		public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
			: base(firstName, lastName)
		{
			WeekSalary = weekSalary;
			WorkHoursPerDay = workHoursPerDay;
		}

		private decimal WeekSalary
		{
			set
			{
				if (value <= MinWeekSalary)
				{
					throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
				}

				weekSalary = value;
			}
		}

		private double WorkHoursPerDay
		{
			set
			{
				if (value < MinWorkingHoursPerDay || value > MaxWorkingHoursPerDay)
				{
					throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHoursPerDay)}");
				}

				workHoursPerDay = value;
			}
		}

		private decimal GetSalaryPerHour()
		{
			decimal salaryPerDay = weekSalary / 5;
			return salaryPerDay / (decimal)workHoursPerDay;
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();

			builder.Append(base.ToString())
				.AppendLine($"Week Salary: {weekSalary:F2}")
				.AppendLine($"Hours per day: {workHoursPerDay:F2}")
				.AppendLine($"Salary per hour: {GetSalaryPerHour():F2}");

			return builder.ToString();
		}
	}
}
