using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.RectangleIntersection
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] firstLine = Console.ReadLine().Split();
			Queue<Rectangle> rectangles = SetRectangles(int.Parse(firstLine[0]));

			CheckIntersections(int.Parse(firstLine[1]), rectangles);
		}

		private static void CheckIntersections(int numberOfIntersectionChecks, Queue<Rectangle> rectangles)
		{
			while (numberOfIntersectionChecks > 0)
			{
				string[] pair = Console.ReadLine().Split();
				Rectangle firstRect = rectangles.Where(r => r.Id == pair[0]).FirstOrDefault();
				Rectangle secondRect = rectangles.Where(r => r.Id == pair[1]).FirstOrDefault();

				Console.WriteLine(firstRect.IsThereIntersection(secondRect) ? "true" : "false");

				numberOfIntersectionChecks--;
			}
		}

		private static Queue<Rectangle> SetRectangles(int numberOfRectangles)
		{
			Queue<Rectangle> rectangles = new Queue<Rectangle>(numberOfRectangles);

			while (rectangles.Count < numberOfRectangles)
			{
				string[] input = Console.ReadLine().Split();
				rectangles.Enqueue(new Rectangle(input[0], double.Parse(input[1]),
				double.Parse(input[2]), double.Parse(input[3]), double.Parse(input[4])));
			}

			return rectangles;
		}
	}
}
