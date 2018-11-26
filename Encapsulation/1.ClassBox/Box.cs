namespace _1.ClassBox
{
	public class Box
	{
		private readonly double _length;

		private readonly double _width;

		private readonly double _height;

		public Box(double length, double width, double height)
		{
			_length = length;
			_width = width;
			_height = height;
		}

		public double SurfaceArea()
		{
			double surfaceArea = 2 * _length * _height + 2 * _width * _height + 2 * _width * _length;
			return surfaceArea;
		}

		public double LateralSurfaceArea()
		{
			double lateralSurfaceArea = 2 * _length * _height + 2 * _width * _height;
			return lateralSurfaceArea;
		}

		public double Volume()
		{
			double volume = _length * _height * _width;
			return volume;
		}

	}
}
