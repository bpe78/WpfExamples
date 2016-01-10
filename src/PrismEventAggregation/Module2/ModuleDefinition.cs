using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Module2
{
	[Module(ModuleName = "Module2")]
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
			container.RegisterType<IModule2ViewModel, Module2ViewModel>();
			
			//container.RegisterType<IModule2View, Module2View>();
			regionManager.RegisterViewWithRegion(Common.RegionNames.Region_1, typeof(Module2View));
		}
	}
}
