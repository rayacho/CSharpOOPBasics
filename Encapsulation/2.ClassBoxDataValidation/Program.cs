using System;

namespace _2.ClassBoxDataValidation
{
	class Program
	{
		static void Main(string[] args)
		{
			double length = double.Parse(Console.ReadLine());
			double width = double.Parse(Console.ReadLine());
			double height = double.Parse(Console.ReadLine());

			try
			{
				Box box = new Box(length, width, height);

				double surfaceArea = Box.SurfaceArea(length, width, height);
				double lateralSurfaceArea = Box.LateralSurfaceArea(length, width, height);
				double volume = Box.Volume(length, width, height);

				Console.WriteLine($"Surface Area - {surfaceArea:F2}");
				Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:F2}");
				Console.WriteLine($"Volume - {volume:F2}");
			}
			catch (ArgumentException exception)
			{
				Console.WriteLine(exception.Message);
			}
		}
	}
}
