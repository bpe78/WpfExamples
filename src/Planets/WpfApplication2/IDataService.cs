using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{
	public interface IDataService
	{
		IList<PlanetEntity> GetPlanets();
	}
}
