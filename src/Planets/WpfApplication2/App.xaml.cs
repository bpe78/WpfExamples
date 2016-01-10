using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Unity;

namespace WpfApplication2
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public IUnityContainer Container { get; set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			Container = new UnityContainer();
			Container.RegisterInstance<IDataService>(new DataService());
			Container.RegisterType<PlanetListViewModel>(new ContainerControlledLifetimeManager());
		}
	}
}
