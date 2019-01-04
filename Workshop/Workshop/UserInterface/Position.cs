using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App
{
	public class Position
	{
		private int _left;
		private int _top;

		public Position(int left, int top)
		{
			Left = left;
			Top = top;
		}

		public int Top
		{
			get
			{
				return _top;
			}
			set
			{
				_top = value;
			}
		}
		public int Left
		{
			get
			{
				return _left;
			}
			set
			{
				_left = value;
			}
		}

		public static Position ConsoleCenter()
		{
			int centerTop = Console.WindowHeight / 2;
			int centerLeft = Console.WindowWidth / 2;

			Position center = new Position(centerLeft, centerTop);
			return center;
		}
	}
}
