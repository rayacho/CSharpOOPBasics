using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _3.Mankind
{
	public class Student : Human
	{
		private const int FacNumMinLength = 5;
		private const int FacNumMaxLength = 10;
		private string facultyNumber;

		public Student(string firstName, string lastName, string facultyNumber)
			: base(firstName, lastName)
		{
			FacultyNumber = facultyNumber;
		}

		private string FacultyNumber
		{
			set
			{
				if (value.Length < FacNumMinLength || value.Length > FacNumMaxLength ||
					!value.All(char.IsLetterOrDigit))
				{
					throw new ArgumentException("Invalid faculty number!");
				}

				facultyNumber = value;
			}
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();

			builder.Append(base.ToString()).AppendLine($"Faculty number: {facultyNumber}");

			return builder.ToString();
		}
	}
}
