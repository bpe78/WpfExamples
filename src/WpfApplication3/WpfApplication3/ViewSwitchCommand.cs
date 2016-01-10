using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApplication3
{
	public class ViewSwitchCommand : ICommand
	{
		private SwitchViewModel _vm;
		public ViewSwitchCommand(SwitchViewModel vm)
		{
			this._vm = vm;
		}
		public bool CanExecute(object parameter)
		{
			return true;
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			switch ((string)parameter)
			{
				case "view1": _vm.CurrentChild = _vm.Child1; break;
				case "view2": _vm.CurrentChild = _vm.Child2; break;
			}
		}
	}
}
