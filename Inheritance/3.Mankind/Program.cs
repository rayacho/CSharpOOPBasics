﻿using System;

namespace _3.Mankind
{
	public class Program
	{
		static void Main(string[] args)
		{
			try
			{
				string[] studentInput = Console.ReadLine().Split();
				string studentFirstName = studentInput[0];
				string studentLastName = studentInput[1];
				string facultyNumber = studentInput[2];

				Student student = new Student(studentFirstName, studentLastName, facultyNumber);

				string[] workerInput = Console.ReadLine().Split();
				string workerFirstName = workerInput[0];
				string workerLastName = workerInput[1];
				decimal weekSalary = decimal.Parse(workerInput[2]);
				double workHours = double.Parse(workerInput[3]);

				Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workHours);

				Console.WriteLine(student);
				Console.WriteLine(worker);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
