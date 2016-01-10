using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace WpfApplication10
{
	public class AddIncomeViewModel : NotificationObject
	{
		ShellViewModel parentVM;
		IncomeItemEntity entityPrototype;

		public AddIncomeViewModel(ShellViewModel parentVM)
		{
			this.parentVM = parentVM;
			entityPrototype = new IncomeItemEntity { Id = 0, Date = DateTime.Today, Category = parentVM.IncomeCategories.FirstOrDefault(), Amount = 0, Details = string.Empty };
		}

		#region Properties

		public ObservableCollection<IncomeCategoryEntity> Categories { get { return parentVM.IncomeCategories; } }

		public int Id
		{
			get { return entityPrototype.Id; }
			set
			{
				if (entityPrototype.Id != value)
				{
					entityPrototype.Id = value;
					RaisePropertyChanged(() => this.Id);
				}
			}
		}

		public DateTime Date
		{
			get { return entityPrototype.Date; }
			set
			{
				if (entityPrototype.Date != value)
				{
					entityPrototype.Date = value;
					RaisePropertyChanged(() => this.Date);
				}
			}
		}

		public IncomeCategoryEntity Category
		{
			get { return entityPrototype.Category; }
			set
			{
				if (entityPrototype.Category != value)
				{
					entityPrototype.Category = value;
					RaisePropertyChanged(() => this.Category);
				}
			}
		}

		public decimal Amount
		{
			get { return entityPrototype.Amount; }
			set
			{
				if (entityPrototype.Amount != value)
				{
					entityPrototype.Amount = value;
					RaisePropertyChanged(() => this.Amount);
				}
			}
		}

		public string Details
		{
			get { return entityPrototype.Details; }
			set
			{
				if (entityPrototype.Details != value)
				{
					entityPrototype.Details = value;
					RaisePropertyChanged(() => this.Details);
				}
			}
		}

		#endregion

		#region Commands

		ICommand addNewCommand;
		public ICommand AddNewCommand
		{
			get { return addNewCommand ?? (addNewCommand = new DelegateCommand(ExecuteAddNewCommand)); }
		}

		private void ExecuteAddNewCommand()
		{
			var newItem = new IncomeItemEntity(entityPrototype);

			Id = 0;
			Amount = 0;
			Details = string.Empty;

			parentVM.Items.Add(newItem);
		}

		#endregion
	}
}
