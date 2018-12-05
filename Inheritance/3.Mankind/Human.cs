using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Mankind
{
	public class Human
	{
		private const int LastNameMinLength = 3;
		private const int FirstNameMinLength = 4;
		private string firstName;
		private string lastName;

		public Human(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

		public string FirstName
		{
			get { return firstName; }
			set
			{
				if (char.IsLower(value[0]))
				{
					throw new ArgumentException($"Expected upper case letter! Argument: {nameof(firstName)}");
				}

				if (value.Length < FirstNameMinLength)
				{
					throw new ArgumentException($"Expected length at least {FirstNameMinLength} symbols! Argument: {nameof(firstName)}");
				}

				firstName = value;
			}
		}

		public string LastName
		{
			get { return lastName; }
			set
			{
				if (char.IsLower(value[0]))
				{
					throw new ArgumentException($"Expected upper case letter! Argument: {nameof(lastName)}");
				}

				if (value.Length < LastNameMinLength)
				{
					throw new ArgumentException($"Expected length at least {LastNameMinLength} symbols! Argument: {nameof(lastName)}");
				}

				lastName = value;
			}
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine($"First Name: {firstName}").AppendLine($"Last Name: {lastName}");

			return builder.ToString();
		}
	}
}
