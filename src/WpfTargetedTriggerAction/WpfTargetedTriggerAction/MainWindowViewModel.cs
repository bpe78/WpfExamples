using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace WpfTargetedTriggerAction
{
    public class MainWindowViewModel : BindableBase
	{
		public event EventHandler XXX;

		public MainWindowViewModel()
		{
		}

		DelegateCommand _exitCmd;
		public ICommand ExitCmd
		{
			get { return _exitCmd ?? (_exitCmd = new DelegateCommand(ExecuteExitCmd)); }
		}

		private void ExecuteExitCmd()
		{
			var handler = XXX;
			if (handler != null)
				handler(this, new EventArgs());
		}

	}

}
