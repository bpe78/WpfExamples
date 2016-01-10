using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication10
{
	class ExpenseItemEntity
	{
		public ExpenseItemEntity()
		{
		}

		public ExpenseItemEntity(ExpenseItemEntity original)
		{
			Id = original.Id;
			Date = original.Date;
			Category = original.Category;
			Amount = original.Amount;
			Details = original.Details;
		}

		public int Id { get; set; }
		public DateTime Date { get; set; }
		public ExpenseCategoryEntity Category { get; set; }
		public decimal Amount { get; set; }
		public string Details { get; set; }
	}
}
