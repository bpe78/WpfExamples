using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Regions;

namespace WpfApplication10
{
	public class MyBootsttrapper : UnityBootstrapper
	{
		protected override System.Windows.DependencyObject CreateShell()
		{
			return Container.Resolve<Shell>();
		}

		protected override void InitializeShell()
		{
			App.Current.MainWindow = (Shell)Shell;
			App.Current.MainWindow.Show();
		}

		protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
		{
			return base.CreateModuleCatalog();
		}

		protected override void InitializeModules()
		{
			base.InitializeModules();

			var regionManager = Container.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion(RegionDefinitions.ListItemsView, () => Container.Resolve<ListItemsView>());
			regionManager.RegisterViewWithRegion(RegionDefinitions.AddIncomeView, () => Container.Resolve<AddIncomeView>());
			regionManager.RegisterViewWithRegion(RegionDefinitions.AddExpenseView, () => Container.Resolve<AddExpenseView>());

		}
	}
}
