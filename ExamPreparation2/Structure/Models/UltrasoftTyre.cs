using System;
using System.Collections.Generic;
using System.Text;

namespace Structure.Models
{
	public class UltrasoftTyre : Tyre
	{
		public UltrasoftTyre(double hardness, double grip)
			: base("Ultrasoft", hardness)
		{
			Grip = grip;
		}

		public double Grip { get; }

		public override double Degradation
		{
			get => base.Degradation;
			protected set
			{
				if (value < 30)
				{
					throw new ArgumentException(OutputMessages.BlownTyre);
				}

				base.Degradation = value;
			}
		}

		public override void CompleteLap()
		{
			base.CompleteLap();

			Degradation -= Grip;
		}
	}
}
