using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfApplication3
{
	public class SwitchViewModel : INotifyPropertyChanged
	{
		public SwitchViewModel()
		{
			this.Child1 = new ViewModel1();
			this.Child2 = new ViewModel2();
		}

		private ViewModel1 _child1;
		public ViewModel1 Child1
		{
			get { return _child1; }

			set
			{
				if (_child1 != value)
				{
					_child1 = value;
					RaiseNotifyPropertyChanged("Child1");
				}
			}
		}

		private ViewModel2 _child2;
		public ViewModel2 Child2
		{
			get { return _child2; }

			set
			{
				if (_child2 != value)
				{
					_child2 = value;
					RaiseNotifyPropertyChanged("Child2");
				}
			}
		}

		private ViewModelBase _currentChild;
		public ViewModelBase CurrentChild
		{
			get
			{
				return _currentChild;
			}

			set
			{
				if (_currentChild != value)
				{
					_currentChild = value;
					RaiseNotifyPropertyChanged("CurrentChild");
				}
			}
		}

		private ViewSwitchCommand _command;
		public ViewSwitchCommand SwitchViewCommand
		{
			get
			{
				if (_command == null)
				{
					_command = new ViewSwitchCommand(this);
				}
				return _command;
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

		private void RaiseNotifyPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
