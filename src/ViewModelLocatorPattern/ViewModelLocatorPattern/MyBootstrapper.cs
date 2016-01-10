using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Regions;

namespace ViewModelLocatorPattern
{
	class MyBootstrapper : UnityBootstrapper
	{
		protected override System.Windows.DependencyObject CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void InitializeShell()
		{
			App.Current.MainWindow = (Window)Shell;
			App.Current.MainWindow.Show();
		}

		protected override void InitializeModules()
		{
			base.InitializeModules();

			var regionManager = Container.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion(RegionDefinitions.Test1ViewRegion, typeof(Views.Test1View));
			regionManager.RegisterViewWithRegion(RegionDefinitions.Test2ViewRegion, typeof(Views.Test2View));
			regionManager.RegisterViewWithRegion(RegionDefinitions.Test3ViewRegion, typeof(Views.Test3View));
		}
	}
}
