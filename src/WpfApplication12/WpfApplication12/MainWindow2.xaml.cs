using System.Windows;

namespace WpfApplication12
{
    public partial class MainWindow2 : Window
	{
		public MainWindow2()
		{
			InitializeComponent();
			DataContext = new ViewModel();
		}
	}
}
