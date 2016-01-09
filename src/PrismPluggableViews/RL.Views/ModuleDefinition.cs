using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;

namespace RL.Views
{
	public class ModuleDefinition : IModule
	{
		#region IModule Members

		public void Initialize()
		{
			var rd = new ResourceDictionary();
			rd.Source = new Uri("pack://application:,,,/RL.Views;component/RlViewsResourceDictionary.xaml");
			Application.Current.Resources.MergedDictionaries.Add(rd);
		}

		#endregion
	}
}
