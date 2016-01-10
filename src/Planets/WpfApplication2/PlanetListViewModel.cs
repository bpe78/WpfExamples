using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;

namespace WpfApplication2
{
	public class PlanetListViewModel
	{
		private static int _counter = 0;
		IDataService _dataService;

		private ObservableCollection<PlanetViewModel> _listPlanets;
		public ObservableCollection<PlanetViewModel> Planets
		{
			get { return _listPlanets; }
		}

		//public PlanetListViewModel(IDataService ds)
		public PlanetListViewModel(IUnityContainer container)
		{
			_counter++;
			this._listPlanets = new ObservableCollection<PlanetViewModel>();
			//this._dataService = ds;
			this._dataService = container.Resolve<IDataService>();
			foreach (var p in _dataService.GetPlanets())
			{
				_listPlanets.Add(new PlanetViewModel(p));
			}
		}
	}
}
