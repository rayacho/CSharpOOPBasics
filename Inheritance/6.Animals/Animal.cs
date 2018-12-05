using System;
using System.Collections.Generic;
using System.Text;

namespace _6.Animals
{
	public class Animal : ISoundProducable
	{
		private const string ErrorMessage = "Invalid input!";
		private string name;
		private int age;
		private string gender;

		public Animal(string name, int age, string gender)
		{
			this.Name = name;
			this.Age = age;
			this.Gender = gender;
		}

		public string Name
		{
			get { return name; }
			set
			{
				NotEmptyValidation(value);
				name = value;
			}
		}

		public int Age
		{
			get { return age; }
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException(ErrorMessage);
				}

				age = value;
			}
		}

		public string Gender
		{
			get { return gender; }
			set
			{
				NotEmptyValidation(value);

				if (value != "Male" && value != "Female")
				{
					throw new ArgumentException(ErrorMessage);
				}

				gender = value;
			}
		}

		private static void NotEmptyValidation(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException(ErrorMessage);
			}
		}

		public virtual string ProduceSound()
		{
			return "NOISE!!!!!";
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{this.GetType().Name}")
				.AppendLine($"{this.Name} {this.Age} {this.Gender}")
				.AppendLine(this.ProduceSound());

			string result = sb.ToString().TrimEnd();
			return result;
		}
	}
}
