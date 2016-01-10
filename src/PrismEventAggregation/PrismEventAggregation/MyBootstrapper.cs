using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace PrismEventAggregation
{
	class MyBootstrapper : UnityBootstrapper
	{
		protected override System.Windows.DependencyObject CreateShell()
		{
			return Container.Resolve<Shell>();
		}

		protected override void InitializeShell()
		{
			App.Current.MainWindow = (Window)Shell;
			App.Current.MainWindow.Show();
		}

		protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
		{
			var catalog = new DirectoryModuleCatalog { ModulePath = @".\" };
			return catalog;
		}
	}
}
