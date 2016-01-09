using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Mvvm;

namespace PitchDemo
{
	class PointViewModel : BindableBase
	{
		public PointViewModel(string id, double x, double y, Teams team)
		{
			this.Id = id;
			this.X = x;
			this.Y = y;
			this.Team = team;
		}

		public string Id { get; private set; }

		double _x;
		public double X
		{
			get { return _x; }
			private set { SetProperty(ref _x, value); }
		}

		double _y;
		public double Y
		{
			get { return _y; }
			private set { SetProperty(ref _y, value); }
		}

		Teams _team;
		public Teams Team
		{
			get { return _team; }
			set { SetProperty(ref _team, value); }
		}

		public void SwitchDirection()
		{
			X = 1 - X;
		}
	}
}
