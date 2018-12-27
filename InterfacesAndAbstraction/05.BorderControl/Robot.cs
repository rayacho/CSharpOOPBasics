using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
	public class Robot : IId, IRobot
	{
		public Robot(string model, string id)
		{
			Model = model;
			Id = id;
		}

		public string Model
		{
			get;
		}

		public string Id
		{
			get;
		}
	}
}
