using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApplication1.Models;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WpfApplication1.ViewModels
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		public MainWindowViewModel()
		{
			_items = new ObservableCollection<IncomeItem>();
			_items.Add(new IncomeItem { Id = 1, Date = DateTime.Parse("2012/01/01"), TypeId = 1, Amount = 10, Description = "Test Object 1" });
			_items.Add(new IncomeItem { Id = 2, Date = DateTime.Parse("2012/02/02"), TypeId = 2, Amount = 20, Description = "Test Object 2" });
			_items.Add(new IncomeItem { Id = 3, Date = DateTime.Parse("2012/03/03"), TypeId = 3, Amount = 30, Description = "Test Object 3" });
			_items.Add(new IncomeItem { Id = 4, Date = DateTime.Parse("2012/04/04"), TypeId = 4, Amount = 40, Description = "Test Object 4" });
		}

		#region Properties

		private IncomeItem _item;
		public IncomeItem SelectedItem
		{
			get { return _item; }
			set
			{
				if (_item != value)
				{
					_item = value;
					RaisePropertyChanged("SelectedItem");
					if(_item != null)
						ActiveItem = _item;
					_newCommand.RaiseCanExecuteChanged();
					_saveCommand.RaiseCanExecuteChanged();
					_deleteCommand.RaiseCanExecuteChanged();
					_exitCommand.RaiseCanExecuteChanged();

				}
			}
		}

		private IncomeItem _activeItem;
		public IncomeItem ActiveItem
		{
			get { return _activeItem; }
			set
			{
				if (_activeItem != value)
				{
					_activeItem = value;
					RaisePropertyChanged("ActiveItem");
				}
			}
		}

		public int Id
		{
			get { return _item.Id; }
			set
			{
				if (_item.Id != value)
				{
					_item.Id = value;
					RaisePropertyChanged("Id");
				}
			}
		}
		
		public DateTime Date
		{
			get { return _item.Date; }
			set
			{
				if (_item.Date != value)
				{
					_item.Date = value;
					RaisePropertyChanged("Date");
				}
			}
		}

		public byte TypeId
		{
			get { return _item.TypeId; }
			set
			{
				if (_item.TypeId != value)
				{
					_item.TypeId = value;
					RaisePropertyChanged("TypeId");
				}
			}
		}

		public int Amount
		{
			get { return _item.Amount; }
			set
			{
				if (_item.Amount != value)
				{
					_item.Amount = value;
					RaisePropertyChanged("Amount");
				}
			}
		}

		public string Description
		{
			get { return _item.Description; }
			set
			{
				if (_item.Description != value)
				{
					_item.Description = value;
					RaisePropertyChanged("Description");
				}
			}
		}

		private ObservableCollection<IncomeItem> _items;
		public ObservableCollection<IncomeItem> Items
		{
			get { return _items; }
			set
			{
				if (_items != value)
				{
					_items = value;
					RaisePropertyChanged("Items");
				}
			}
		}

		#endregion

		#region Commands

		private DelegateCommand _newCommand;
		public DelegateCommand NewCommand
		{
			get
			{
				if (_newCommand == null)
				{
					_newCommand = new DelegateCommand(ExecuteNew);
				}
				return _newCommand;
			}
		}

		private DelegateCommand _saveCommand;
		public DelegateCommand SaveCommand
		{
			get
			{
				if (_saveCommand == null)
				{
					_saveCommand = new DelegateCommand(ExecuteSave);
				}
				return _saveCommand;
			}
		}

		private DelegateCommand _deleteCommand;
		public DelegateCommand DeleteCommand
		{
			get
			{
				if (_deleteCommand == null)
				{
					_deleteCommand = new DelegateCommand(ExecuteDelete, CanExecuteDelete);
					//_deleteCommand = new DelegateCommand(ExecuteDelete);
				}
				return _deleteCommand;
			}
		}

		private DelegateCommand _exitCommand;
		public DelegateCommand ExitCommand
		{
			get
			{
				if (_exitCommand == null)
				{
					_exitCommand = new DelegateCommand(ExecuteExit);
				}
				return _exitCommand;
			}
		}

		private void ExecuteNew()
		{
			this.ActiveItem = new IncomeItem();
			this.SelectedItem = null;
		}

		private void ExecuteSave()
		{
			if (this.ActiveItem != null)
			{
				this.Items.Add(this.ActiveItem);
				this.SelectedItem = this.ActiveItem = null;
			}
		}

		private void ExecuteDelete()
		{
			if (this.SelectedItem != null)
			{
				this.Items.Remove(this.SelectedItem);
				this.SelectedItem = null;
				this.ActiveItem = null;
			}
		}

		private bool CanExecuteDelete()
		{
			return (this.SelectedItem != null);
		}

		private void ExecuteExit()
		{
		}


		#endregion

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void RaisePropertyChanged(string propertyName)
		{
			var handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion
	}
}
