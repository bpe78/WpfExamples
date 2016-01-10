using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Controls;

namespace WpfApplication2
{
	public class PlanetViewModel : INotifyPropertyChanged
	{
		private PlanetEntity _planet;

		public PlanetViewModel()
		{
			_planet = new PlanetEntity();
		}

		public PlanetViewModel(PlanetEntity p)
		{
			this._planet = p;
		}

		public string Name
		{
			get { return _planet.Name; }
			set
			{
				if (_planet.Name != value)
				{
					_planet.Name = value;
					RaisePropertyChanged("Name");
				}
			}
		}

		public string Description
		{
			get { return _planet.Description; }
			set
			{
				if (_planet.Description != value)
				{
					_planet.Description = value;
					RaisePropertyChanged("Description");
				}
			}
		}

		public Uri Picture
		{
			get { return _planet.Picture; }
			set
			{
				if (_planet.Picture != value)
				{
					_planet.Picture = value;
					RaisePropertyChanged("Picture");
				}
			}
		}

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion
	}
}
