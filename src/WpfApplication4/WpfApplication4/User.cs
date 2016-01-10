using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfApplication4
{
	public class User : INotifyPropertyChanged
	{
		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}

		private string _phone;
		public string Phone
		{
			get { return _phone; }
			set
			{
				_phone = value;
				OnPropertyChanged("Phone");
			}
		}

		private string _country;
		public string Country
		{
			get { return _country; }
			set
			{
				_country = value;
				OnPropertyChanged("Country");
			}
		}

		private double _total;
		public double Total
		{
			get { return _total; }
			set
			{
				_total = value;
				OnPropertyChanged("Total");
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

	}
}
