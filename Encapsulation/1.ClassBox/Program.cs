using System;

namespace _1.ClassBox
{
	class Program
	{
		static void Main(string[] args)
		{
			double length = double.Parse(Console.ReadLine());
			double width = double.Parse(Console.ReadLine());
			double height = double.Parse(Console.ReadLine());

			double surfaceArea = Box.SurfaceArea(length, width, height);
			double lateralSurfaceArea = Box.LateralSurfaceArea(length, width, height);
			double volume = Box.Volume(length, width, height);

			Console.WriteLine($"Surface Area - {surfaceArea:F2}");
			Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:F2}");
			Console.WriteLine($"Volume - {volume:F2}");
		}
	}
}
