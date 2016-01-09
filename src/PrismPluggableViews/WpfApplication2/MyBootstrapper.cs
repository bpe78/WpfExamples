using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace WpfApplication2
{
	class MyBootstrapper : UnityBootstrapper
	{
		protected override DependencyObject CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void InitializeShell()
		{
			App.Current.MainWindow = (Window)Shell;
			App.Current.MainWindow.Show();
		}

		protected override IModuleCatalog CreateModuleCatalog()
		{
            var catalog = new DirectoryModuleCatalog { ModulePath = @"..\..\..\_Modules" };
            return catalog;
		}

		protected override void InitializeModules()
		{
			base.InitializeModules();
		}
	}
}
