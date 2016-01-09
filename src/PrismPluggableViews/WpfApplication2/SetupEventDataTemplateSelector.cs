using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication2
{
	class SetupEventDataTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			var dataTemplate = (DataTemplate)App.Current.TryFindResource("keyRLSetupEventView");
			return dataTemplate;
			//return base.SelectTemplate(item, container);
		}
	}
}
