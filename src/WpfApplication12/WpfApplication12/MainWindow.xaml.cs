using System.Windows;

namespace WpfApplication12
{
    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new ViewModel();
		}
	}
}
