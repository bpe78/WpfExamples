using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication10
{
	public class IncomeItemEntity
	{
		public IncomeItemEntity()
		{
		}

		public IncomeItemEntity(IncomeItemEntity original)
		{
			Id = original.Id;
			Date = original.Date;
			Category = original.Category;
			Amount = original.Amount;
			Details = original.Details;
		}

		public int Id { get; set; }
		public DateTime Date { get; set; }
		public IncomeCategoryEntity Category { get; set; }
		public decimal Amount { get; set; }
		public string Details { get; set; }
	}
}
