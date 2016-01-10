using System.Windows;
using System.Windows.Controls;

namespace WpfApplication12
{
    public class ItemTemplateSelector : DataTemplateSelector
	{
		public DataTemplate IncomeItemTemplate { get; set; }
		public DataTemplate ExpenseItemTemplate { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is IncomeItemEntity)
				return IncomeItemTemplate;
			if (item is ExpenseItemEntity)
				return ExpenseItemTemplate;

			return base.SelectTemplate(item, container);
		}
	}
}
