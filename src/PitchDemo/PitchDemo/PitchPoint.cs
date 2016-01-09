using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchDemo
{
	public class PitchPoint
	{
		public PitchPoint()
			: this(0, 0)
		{
		}

		public PitchPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		public double X { get; set; }
		public double Y { get; set; }
	}

}
