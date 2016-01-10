using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WpfApplication2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<Item> _cv;

		public MainWindow()
		{
			InitializeComponent();

			_cv = new List<Item>();
			_cv.Add(new Item { Id = 1, Date= DateTime.Parse("2012/01/10"), Amount = 100, Type = 1});
			_cv.Add(new Item { Id = 2, Date= DateTime.Parse("2012/01/15"), Amount = 300, Type = 2});
			_cv.Add(new Item { Id = 3, Date= DateTime.Parse("2012/01/15"), Amount = 400, Type = 3});
			_cv.Add(new Item { Id = 4, Date= DateTime.Parse("2012/01/15"), Amount = 500, Type = 3});
			_cv.Add(new Item { Id = 5, Date= DateTime.Parse("2012/01/30"), Amount = 200, Type = 2});
			_cv.Add(new Item { Id = 6, Date= DateTime.Parse("2012/02/01"), Amount = 100, Type = 2});
			_cv.Add(new Item { Id = 7, Date= DateTime.Parse("2012/02/10"), Amount =1200, Type = 3});
			_cv.Add(new Item { Id = 8, Date= DateTime.Parse("2012/02/20"), Amount = 300, Type = 1});
			_cv.Add(new Item { Id = 9, Date= DateTime.Parse("2012/03/10"), Amount = 200, Type = 1});
			_cv.Add(new Item { Id =10, Date= DateTime.Parse("2012/03/15"), Amount =1500, Type = 2});
			_cv.Add(new Item { Id =11, Date= DateTime.Parse("2012/04/11"), Amount = 100, Type = 2});
			_cv.Add(new Item { Id =12, Date= DateTime.Parse("2012/04/16"), Amount = 130, Type = 3});

			ICollectionView icv = CollectionViewSource.GetDefaultView(_cv);
			// Grouping
			icv.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
			icv.GroupDescriptions.Add(new PropertyGroupDescription("Date"));
			// Sorting
			icv.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));

			this.DataContext = _cv;
		}
	}
}
