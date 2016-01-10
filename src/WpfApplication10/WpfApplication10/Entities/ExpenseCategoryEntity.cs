using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication10
{
	public class ExpenseCategoryEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ExpenseCategoryEntity Parent { get; set; }
	}
}
