using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfApplication6
{
	public class PersonViewModel : ContextBoundObject, INotifyPropertyChanged
	{
		private object _guard = new object();

		private List<string> _firstNames = new List<string>();
		private string _firstName;
		public string FirstName
		{
			get
			{
				lock (_guard)
				{
					_firstNames.Add(_firstName);
					return _firstName;
				}
			}
			set
			{
				lock (_guard)
				{
					if (_firstName != value)
					{
						_firstName = value;
						OnPropertyChanged("FirstName");
					}
				}
			}
		}

		private List<string> _lastNames = new List<string>();
		private string _lastName;
		public string LastName
		{
			get
			{
				_lastNames.Add(_lastName);
				return _lastName;
			}
			set
			{
				if (_lastName != value)
				{
					_lastName = value;
					OnPropertyChanged("LastName");
				}
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
