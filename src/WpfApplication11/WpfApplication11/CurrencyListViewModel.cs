using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace WpfApplication11
{
    class CurrencyListViewModel : BindableBase
	{
		ICollectionView cvsCurrencies;

		public CurrencyListViewModel()
		{
			_isNewInProgress = false;

			Currencies = new ObservableCollection<CurrencyDetailsViewModel>();
			cvsCurrencies = CollectionViewSource.GetDefaultView(Currencies);
			cvsCurrencies.CurrentChanged += Currencies_CurrentChanged;

			Currencies.Add(new CurrencyDetailsViewModel(this, new CurrencyEntity { Id = 1, Symbol = "RON", Description = "Romanian Leu" }));
			Currencies.Add(new CurrencyDetailsViewModel(this, new CurrencyEntity { Id = 2, Symbol = "EUR", Description = "Euro" }));
		}

		private void Currencies_CurrentChanged(object sender, EventArgs e)
		{
            OnPropertyChanged(() => this.CurrentItem);
		}

		public ObservableCollection<CurrencyDetailsViewModel> Currencies { get; private set; }

		#region Properties

		bool _isNewInProgress;
		public bool IsNewInProgress
		{
			get { return _isNewInProgress; }
			set
			{
				if (_isNewInProgress != value)
				{
					_isNewInProgress = value;
                    OnPropertyChanged(() => this.IsNewInProgress);
                    OnPropertyChanged(() => this.IsInterfaceLocked);
				}
			}
		}

		public bool IsInterfaceLocked
		{
			get { return !_isNewInProgress; }
		}

		public CurrencyDetailsViewModel CurrentItem
		{
			get
			{
				if (IsNewInProgress)
					return NewItem;
				else
					return CollectionViewSource.GetDefaultView(Currencies).CurrentItem as CurrencyDetailsViewModel;
			}
		}

		CurrencyDetailsViewModel _newItem;
		public CurrencyDetailsViewModel NewItem
		{
			get { return _newItem; }
			set
			{
				if (_newItem != value)
				{
					if((value == null) && (_newItem != null))
					{
						Currencies.Remove(_newItem);
						CollectionViewSource.GetDefaultView(Currencies).MoveCurrentToPrevious();
					}

					_newItem = value;
                    OnPropertyChanged(() => this.NewItem);
				}
			}
		}

		#endregion

		#region Commands

		ICommand _addNewCmd;
		public ICommand AddNewCmd
		{
			get { return _addNewCmd ?? (_addNewCmd = new DelegateCommand(ExecuteAddNew)); }
		}

		private void ExecuteAddNew()
		{
			IsNewInProgress = true;
			NewItem = new CurrencyDetailsViewModel(this, new CurrencyEntity());
            OnPropertyChanged(() => this.CurrentItem);
			//Currencies.Add(NewItem);
			//CollectionViewSource.GetDefaultView(Currencies).MoveCurrentToLast();
		}

		//leg DetailsViewModel de un CurentItem
		#endregion

		public void AddNewItem(CurrencyDetailsViewModel currencyDetailsViewModel)
		{
			Currencies.Add(NewItem);
			CollectionViewSource.GetDefaultView(Currencies).MoveCurrentToLast();
			IsNewInProgress = false;
		}
	}
}
