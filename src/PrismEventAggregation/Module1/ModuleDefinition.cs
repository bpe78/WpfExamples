using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Module1
{
	[Module(ModuleName="Module1")]
	public class ModuleDefinition : IModule
	{
		IUnityContainer container;
		IRegionManager regionManager;

		public ModuleDefinition(IUnityContainer container, IRegionManager regionManager)
		{
			this.container = container;
			this.regionManager = regionManager;
		}

		public void Initialize()
		{
			container.RegisterType<IModule1ViewModel, Module1ViewModel>();
			
			//container.RegisterType<IModule1View, Module1View>();
			regionManager.RegisterViewWithRegion(Common.RegionNames.Region_0, typeof(Module1View));

		}
	}
}
