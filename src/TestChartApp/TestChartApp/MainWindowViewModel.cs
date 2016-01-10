using System.Collections.ObjectModel;

namespace TestChartApp
{
    public class MainWindowViewModel
	{
		public MainWindowViewModel()
		{
			Items = new CountryCollection();
		}

		public CountryCollection Items {get;set;}
	}


	public class CountryCollection : Collection<Country>
	{
		public CountryCollection() // Constructor to add Country objects to the CountryCollection
		{
			Add(new Country("China", 1336718015));
			Add(new Country("India", 1189172906));
			Add(new Country("United States", 313232044));
			Add(new Country("Indonesia", 245613043));
			Add(new Country("Brazil", 203429773));
		}
	}

	public class Country
	{
		public Country(string name, int population)
		{
			Name = name;
			Population = population;
		}

		public string Name { get; set; }
		public int Population { get; set; }
	}
}
