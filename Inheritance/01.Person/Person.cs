using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Person
{
	public class Person
	{
		public const int minLength = 3;
		private string _name;
		private int _age;

		public virtual string Name
		{
			get { return _name; }
			set
			{
				if(value.Length < 3)
				{
					throw new ArgumentException($"Name's length should not be less than {minLength} symbols!");
				}
				_name = value;
			}
		}

		public virtual int Age
		{
			get { return _age; }
			set
			{
				if(value < 0)
				{
					throw new ArgumentException("Age must be positive!");
				}
				_age = value;
			}
		}

		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(String.Format("Name: {0}, Age: {1}", Name, Age));

			return stringBuilder.ToString();
		}
	}

	public class Child : Person
	{
		private const int MaxAge = 15;
		
		public Child(string name, int age) : base(name, age)
		{
		}

		public override int Age
		{
			get
			{
				return base.Age;
			}
			set
			{ 
				if (value > MaxAge)
				{
					throw new ArgumentException($"Child's age must be less than {MaxAge}!");
				}

				base.Age = value;
			}
		}
	}
}

