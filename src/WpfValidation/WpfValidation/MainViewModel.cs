using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DomainModel;
using DomainModel.BaseModel;
using Microsoft.Practices.Prism.Commands;

namespace WpfValidation
{
	class MainViewModel : ObservableObject, IDataErrorInfo
	{
		Device _device;
		Client _client;

		public MainViewModel()
		{
			Device = new Device();
		}

		public Device Device
		{
			get { return _device; }
			set { SetProperty(ref _device, value); }
		}

		private DelegateCommand _saveCmd;
		public ICommand SaveCommand
		{
			get { return _saveCmd ?? (_saveCmd = new DelegateCommand(ExecuteSaveCmd, CanExecuteSaveCmd)); }
		}

		private void ExecuteSaveCmd()
		{
			if(!CanExecuteSaveCmd()) throw new InvalidOperationException();

			//throw new NotImplementedException();
		}

		private bool CanExecuteSaveCmd()
		{
			List<ValidationResult> validationResults = new List<ValidationResult>();
			ValidationContext ctx = new ValidationContext(_device, null, null);
			if (!Validator.TryValidateObject(_device, ctx, validationResults))
				return false;

			return true;
		}

		#region IDataErrorInfo Members

		public string Error
		{
			get { throw new NotImplementedException(); }
		}

		public string this[string propertyName]
		{
			get { return _device[propertyName]; }
		}

		#endregion
	}
}
