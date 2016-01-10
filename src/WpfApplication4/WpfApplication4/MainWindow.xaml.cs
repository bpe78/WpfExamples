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

namespace WpfApplication4
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			MyDataSource ds = FindResource("MyData") as MyDataSource;
			ds.CollectionChanged += (s, e) =>
				{
					CollectionViewSource cvs = FindResource("ViewSource") as CollectionViewSource;
					if (cvs != null)
						cvs.View.Refresh();
				};
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MyDataSource s = FindResource("MyData") as MyDataSource;
			if (s != null)
			{
				User u = s[2];
				s.Remove(u);
				u.Total += 100;
				s.Add(u);
			}
		}
	}
}
