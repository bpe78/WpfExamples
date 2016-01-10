using System;
using Microsoft.Practices.Prism.Mvvm;

namespace WpfApplication12
{
    public class ItemEntity : BindableBase
	{
		private int _id;
		public int Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}

		private DateTime _date;
		public DateTime Date
		{
			get { return _date; }
            set { SetProperty(ref _date, value); }
		}

		private string _name;
		public string Name
		{
			get { return _name; }
            set { SetProperty(ref _name, value); }
		}

		public virtual bool? ItemType
		{
			get { return null; }
		}
	}

	public class IncomeItemEntity : ItemEntity
	{
		public override bool? ItemType
		{
			get { return true; }
		}
	}

	public class ExpenseItemEntity : ItemEntity
	{
		public override bool? ItemType
		{
			get { return false; }
		}
	}
}
