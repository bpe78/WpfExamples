using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace WpfApplication12
{
    public class ViewModel : BindableBase
	{
		ICollectionView _collectionView;
		public ViewModel()
		{
			Items = new ObservableCollection<ItemEntity>();
			Items.Add(new IncomeItemEntity{ Id = 1, Date = DateTime.Today.AddDays(-10), Name = "Salariu" });
			Items.Add(new IncomeItemEntity { Id = 2, Date = DateTime.Today.AddDays(-1), Name = "Bonus" });
			Items.Add(new IncomeItemEntity { Id = 3, Date = DateTime.Today.AddDays(-5), Name = "Dobanda" });
			Items.Add(new IncomeItemEntity { Id = 4, Date = DateTime.Today.AddDays(-5), Name = "APIA" });
			Items.Add(new IncomeItemEntity { Id = 5, Date = DateTime.Today.AddDays(-2), Name = "APIA" });
			Items.Add(new IncomeItemEntity { Id = 6, Date = DateTime.Today.AddDays(-2), Name = "Salariu" });

			Items.Add(new ExpenseItemEntity { Id = 7, Date = DateTime.Today.AddDays(-10), Name = "Mancare" });
			Items.Add(new ExpenseItemEntity { Id = 8, Date = DateTime.Today.AddDays(-1), Name = "Suc" });
			Items.Add(new ExpenseItemEntity { Id = 9, Date = DateTime.Today.AddDays(-5), Name = "Dulciuri" });
			Items.Add(new ExpenseItemEntity { Id =10, Date = DateTime.Today.AddDays(-5), Name = "Mancare" });
			Items.Add(new ExpenseItemEntity { Id =11, Date = DateTime.Today.AddDays(-2), Name = "Dulciuri" });
			Items.Add(new ExpenseItemEntity { Id =12, Date = DateTime.Today.AddDays(-2), Name = "Haine" });

			_collectionView = CollectionViewSource.GetDefaultView(Items);

			_collectionView.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));
			_collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Date"));
		}

		#region Properties

		public ObservableCollection<ItemEntity> Items { get; set; }

		DateTime _item1 = DateTime.Today;
		public DateTime Item1
		{
			get { return _item1; }
            set { SetProperty(ref _item1, value); }
		}

		DateTime _item2 = DateTime.Today;
		public DateTime Item2
		{
			get { return _item2; }
            set { SetProperty(ref _item2, value); }
        }

        #endregion

        #region Commands

        DelegateCommand _addItem1Cmd;
		public ICommand AddItem1Cmd
		{
			get { return _addItem1Cmd ?? (_addItem1Cmd = new DelegateCommand(ExecuteAddItem1)); }
		}

		private void ExecuteAddItem1()
		{
			Items.Add(new IncomeItemEntity { Id = Items.Count, Date = DateTime.Today, Name = string.Format("Item {0}", Items.Count) });
		}

		DelegateCommand _addItem2Cmd;
		public ICommand AddItem2Cmd
		{
			get { return _addItem2Cmd ?? (_addItem2Cmd = new DelegateCommand(ExecuteAddItem2)); }
		}

		private void ExecuteAddItem2()
		{
			Items.Add(new ExpenseItemEntity { Id = Items.Count, Date = DateTime.Today.AddDays(3), Name = string.Format("Item {0}", Items.Count) });
		}

		DelegateCommand _updateItem1Cmd;
		public ICommand UpdateItem1Cmd
		{
			get { return _updateItem1Cmd ?? (_updateItem1Cmd = new DelegateCommand(ExecuteUpdateItem1)); }
		}

		private void ExecuteUpdateItem1()
		{
			var item = Items.FirstOrDefault(e => (e is IncomeItemEntity) && (e.Date.Day < 10));
			if (item != null)
			{
				item.Date = Item1;
				_collectionView.Refresh();
			}
		}

		DelegateCommand _updateItem2Cmd;
		public ICommand UpdateItem2Cmd
		{
			get { return _updateItem2Cmd ?? (_updateItem2Cmd = new DelegateCommand(ExecuteUpdateItem2)); }
		}

		private void ExecuteUpdateItem2()
		{
			var item = Items.FirstOrDefault(e => e is ExpenseItemEntity);
			if (item != null)
			{
				item.Date = Item2;
				_collectionView.Refresh();
			}
		}

		#endregion
	}
}
