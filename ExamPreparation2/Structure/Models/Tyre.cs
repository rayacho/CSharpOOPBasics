using System;
using System.Collections.Generic;
using System.Text;

namespace Structure.Models
{
	public abstract class Tyre
	{
		private double _degradation;

		protected Tyre(string name, double hardness)
		{
			Name = name;
			Hardness = hardness;
			Degradation = 100;
		}

		public string Name { get; }
		public double Hardness { get; }
		public virtual double Degradation
		{
			get { return _degradation; }
			protected set
			{
				if (value < 0)
				{
					throw new ArgumentException(OutputMessages.BlownTyre);
				}

				_degradation = value;
			}
		}

		public virtual void CompleteLap()
		{
			Degradation -= Hardness;
		}

	}
}
