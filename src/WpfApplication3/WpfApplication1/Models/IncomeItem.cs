using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1.Models
{
	public class IncomeItem
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public byte TypeId { get; set; }
		public int Amount { get; set; }
		public string Description { get; set; }
	}
}
