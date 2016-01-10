using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace WpfApplication11
{
    class CurrencyDetailsViewModel : BindableBase
	{
		CurrencyListViewModel _parentVM;
		CurrencyEntity _entity;

		public CurrencyDetailsViewModel(CurrencyListViewModel parentVM, CurrencyEntity entity)
		{
			_parentVM = parentVM;
			_entity = entity;
			IsCommandVisible = _parentVM.IsNewInProgress;
		}

		#region Properties

		public int Id
		{
			get { return _entity.Id; }
			set
			{
				if (_entity.Id != value)
				{
					_entity.Id = value;
					OnPropertyChanged(() => this.Id);
				}
			}
		}

		public string Symbol
		{
			get { return _entity.Symbol; }
			set
			{
				if (_entity.Symbol != value)
				{
					_entity.Symbol = value;
                    OnPropertyChanged(() => this.Symbol);
				}
			}
		}

		public string Description
		{
			get { return _entity.Description; }
			set
			{
				if (_entity.Description != value)
				{
					_entity.Description = value;
                    OnPropertyChanged(() => this.Description);
				}
			}
		}

		public bool IsCommandVisible
		{
			get { return _parentVM.IsNewInProgress; }
			set
			{
				if (_parentVM.IsNewInProgress != value)
				{
					_parentVM.IsNewInProgress = value;
                    OnPropertyChanged(() => this.IsCommandVisible);
				}
			}
		}

		#endregion

		#region Commands

		ICommand _okCmd;
		public ICommand OkCmd
		{
			get { return _okCmd ?? (_okCmd = new DelegateCommand(ExecuteOk)); }
		}

		private void ExecuteOk()
		{
			IsCommandVisible = false;
			_parentVM.AddNewItem(this);
		}

		ICommand _cancelCmd;
		public ICommand CancelCmd
		{
			get { return _cancelCmd ?? (_cancelCmd = new DelegateCommand(ExecuteCancel)); }
		}

		private void ExecuteCancel()
		{
			IsCommandVisible = false;
			_parentVM.NewItem = null;
		}

		#endregion

	}
}
