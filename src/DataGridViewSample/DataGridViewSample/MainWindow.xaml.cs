using System.Windows;

namespace DataGridViewSample
{
    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new UserGroupsViewModel();
		}
	}
}
