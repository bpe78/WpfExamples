using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxEnabledItems
{
	public class IncomeItemEntity
	{
		public int Id { get; set; }
		public string Symbol { get; set; }
		public IncomeItemEntity Parent { get; set; }
	}
}
