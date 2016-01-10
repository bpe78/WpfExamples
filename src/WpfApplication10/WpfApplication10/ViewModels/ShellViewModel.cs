using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;

namespace WpfApplication10
{
	public class ShellViewModel : NotificationObject
	{
		public ShellViewModel()
		{
			Items = new ObservableCollection<object>();
			IncomeCategories = new ObservableCollection<IncomeCategoryEntity>();
			IncomeCategories.Add(new IncomeCategoryEntity { Id = 1, Name = "Salariu", Parent = null });
			IncomeCategories.Add(new IncomeCategoryEntity { Id = 1, Name = "Bonus", Parent = null });
			IncomeCategories.Add(new IncomeCategoryEntity { Id = 1, Name = "Dobanzi", Parent = null });

			ExpenseCategories = new ObservableCollection<ExpenseCategoryEntity>();
			ExpenseCategories.Add(new ExpenseCategoryEntity { Id = 1, Name = "Mancare", Parent = null });
			ExpenseCategories.Add(new ExpenseCategoryEntity { Id = 1, Name = "Bautura", Parent = null });
			ExpenseCategories.Add(new ExpenseCategoryEntity { Id = 1, Name = "Sanitare", Parent = null });
			ExpenseCategories.Add(new ExpenseCategoryEntity { Id = 1, Name = "Medical", Parent = null });


			ListItemsVM = new ListItemsViewModel(this);
			AddIncomeVM = new AddIncomeViewModel(this);
			AddExpenseVM = new AddExpenseViewModel(this);
		}

		public ObservableCollection<object> Items { get; private set; }

		public ObservableCollection<IncomeCategoryEntity> IncomeCategories { get; private set; }

		public ObservableCollection<ExpenseCategoryEntity> ExpenseCategories { get; private set; }

		public ListItemsViewModel ListItemsVM { get; private set; }

		public AddIncomeViewModel AddIncomeVM { get; private set; }

		public AddExpenseViewModel AddExpenseVM { get; private set; }

	}
}
