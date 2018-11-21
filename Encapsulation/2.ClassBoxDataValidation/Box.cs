using System;
using System.Collections.Generic;
using System.Text;

namespace _2.ClassBoxDataValidation
{
	public class Box
	{
		private double length;
		private double width;
		private double height;


		public Box(double length, double width, double height)
		{
			this.Length = length;
			this.Width = width;
			this.Height = height;
		}

		public double Length
		{
			get { return this.length; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Length cannot be zero or negative.");
				}
				length = value;
			}
		}

		public double Width
		{
			get { return this.width; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Width cannot be zero or negative.");
				}
				width = value;
			}
		}

		public double Height
		{
			get { return this.height; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Height cannot be zero or negative.");
				}
				height = value;
			}
		}

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
