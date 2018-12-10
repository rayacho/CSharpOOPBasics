using System;
using System.Collections.Generic;
using System.Text;

namespace _9.RectangleIntersection
{
	class Rectangle
	{
		private string _id;
		private double _width;
		private double _height;
		private double _topLeftX;
		private double _topLeftY;

		public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
		{
			_id = id;
			_width = Math.Abs(width);
			_height = Math.Abs(height);
			_topLeftX = topLeftX;
			_topLeftY = topLeftY;
		}

		public string Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		public bool IsThereIntersection(Rectangle rectangle)
		{
			if(rectangle == null)
			{
				throw new ArgumentNullException();
			}

			bool result = rectangle._topLeftX + rectangle._width >= _topLeftX &&
				rectangle._topLeftX <= _topLeftX + _width &&
				rectangle._topLeftY >= _topLeftY - _height &&
				rectangle._topLeftY - rectangle._height <= _topLeftY;
			return result;
		}
	}
}
