using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WpfApplication2
{
	public class DataService : IDataService
	{
		public DataService()
		{
		}

		public IList<PlanetEntity> GetPlanets()
		{
			List<PlanetEntity> result = new List<PlanetEntity>();
			result.Add(new PlanetEntity() { Name = "Mercur", Description = "Planeta 1", Picture = ImageNameFromResource("Images/1-Mercury.gif") });
			result.Add(new PlanetEntity() { Name = "Venus", Description = "Planeta 2", Picture = ImageNameFromResource("Images/2-Venus.gif") });
			result.Add(new PlanetEntity() { Name = "Pamant", Description = "Planeta 3", Picture = ImageNameFromResource("Images/3-Earth.gif") });
			result.Add(new PlanetEntity() { Name = "Marte", Description = "Planeta 4", Picture = ImageNameFromResource("Images/4-Mars.gif") });
			result.Add(new PlanetEntity() { Name = "Jupiter", Description = "Planeta 5", Picture = ImageNameFromResource("Images/5-Jupiter.gif") });
			result.Add(new PlanetEntity() { Name = "Saturn", Description = "Planeta 6", Picture = ImageNameFromResource("Images/6-Saturn.gif") });
			result.Add(new PlanetEntity() { Name = "Neptun", Description = "Planeta 7", Picture = ImageNameFromResource("Images/7-Neptune.gif") });
			result.Add(new PlanetEntity() { Name = "Uranus", Description = "Planeta 8", Picture = ImageNameFromResource("Images/8-Uranus.gif") });
			result.Add(new PlanetEntity() { Name = "Pluto", Description = "Planeta 9", Picture = ImageNameFromResource("Images/9-Pluto.gif") });

			return result;
		}

		/// <summary>
		/// Load a resource WPF-BitmapImage (png, bmp, ...) from embedded resource defined as 'Resource' not as 'Embedded resource'.
		/// </summary>
		/// <param name="pathInApplication">Path without starting slash</param>
		/// <param name="assembly">Usually 'Assembly.GetExecutingAssembly()'. If not mentionned, I will use the calling assembly</param>
		/// <returns></returns>
		private Uri ImageNameFromResource(string pathInApplication, Assembly assembly = null)
		{
			if (assembly == null)
			{
				assembly = Assembly.GetExecutingAssembly();
			}

			if (pathInApplication[0] == '/')
			{
				pathInApplication = pathInApplication.Substring(1);
			}
		
			return new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication, UriKind.Absolute);
		}
	}
}
