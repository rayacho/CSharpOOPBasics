using System;
using System.Collections.Generic;
using System.Text;

namespace _1.ClassBox
{
	public class Box
	{
		private double Length { get; set; }

		private double Width { get; set; }

		private double Height { get; set; }

		public static double SurfaceArea(double length, double width, double height)
		{
			double surfaceArea = 2 * length * height + 2 * width * height + 2 * width * length;
			return surfaceArea;
		}

		public static double LateralSurfaceArea(double length, double width, double height)
		{
			double lateralSurfaceArea = 2 * length * height + 2 * width * height;
			return lateralSurfaceArea;
		}

		public static double Volume(double length, double width, double height)
		{
			double volume = length * height * width;
			return volume;
		}

	}
}
