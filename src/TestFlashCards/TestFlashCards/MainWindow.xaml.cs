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
using System.Windows.Media.Animation;


namespace TestFlashCards
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Canvas_KeyDown(object sender, KeyEventArgs e)
		{
			const double duration = 0.5;
			switch (e.Key)
			{
				case Key.Left:
				{
					double fromValue, toValue;

					fromValue = Canvas.GetLeft(currentCard);
					toValue = 10;
					DoubleAnimation animation1 = new DoubleAnimation(fromValue, toValue, new Duration(TimeSpan.FromSeconds(duration)));

					Storyboard.SetTargetName(animation1, "currentCard");
					Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));

					fromValue = Canvas.GetTop(currentCard);
					toValue = 10;
					DoubleAnimation animation2 = new DoubleAnimation(fromValue, toValue, new Duration(TimeSpan.FromSeconds(duration)));

					Storyboard.SetTargetName(animation2, "currentCard");
					Storyboard.SetTargetProperty(animation2, new PropertyPath(Canvas.TopProperty));

					Storyboard sb = new Storyboard();
					sb.Children.Add(animation1);
					sb.Children.Add(animation2);
					sb.Begin(_canvas);

					
/*
					double fromValue = Canvas.GetLeft(currentCard), toValue = 10;
					DoubleAnimation animation1 = new DoubleAnimation(fromValue, toValue, new Duration(TimeSpan.FromSeconds(duration)));
					animation1.AutoReverse = false;

					fromValue = Canvas.GetTop(currentCard);
					toValue = 10;
					DoubleAnimation animation2 = new DoubleAnimation(fromValue, toValue, new Duration(TimeSpan.FromSeconds(duration)));
					animation2.AutoReverse = false;
					currentCard.BeginAnimation(Canvas.LeftProperty, animation1);
					currentCard.BeginAnimation(Canvas.TopProperty, animation2);
*/ 
				} break;

				case Key.Right:
				{
					double fromValue = Canvas.GetLeft(currentCard), toValue = _canvas.ActualWidth - currentCard.ActualWidth - 10;
					DoubleAnimation animation1 = new DoubleAnimation(fromValue, toValue, new Duration(TimeSpan.FromSeconds(duration)));
					animation1.AutoReverse = false;

					fromValue = Canvas.GetTop(currentCard);
					toValue = 10;
					DoubleAnimation animation2 = new DoubleAnimation(fromValue, toValue, new Duration(TimeSpan.FromSeconds(duration)));
					animation2.AutoReverse = false;
					currentCard.BeginAnimation(Canvas.LeftProperty, animation1);
					currentCard.BeginAnimation(Canvas.TopProperty, animation2);
				} break;

				case Key.Up:
				{
					double originalHeight = currentCard.ActualHeight;
					double fromValue = originalHeight, toValue = 0;
					DoubleAnimation animation1 = new DoubleAnimation(fromValue, toValue, new Duration(TimeSpan.FromSeconds(duration)));

					fromValue = Canvas.GetTop(currentCard);
					toValue = fromValue + originalHeight / 2;
					DoubleAnimation animation2 = new DoubleAnimation(fromValue, toValue, new Duration(TimeSpan.FromSeconds(duration)));

					animation1.Completed += (o, ev) =>
					{
						fromValue = 0;
						toValue = originalHeight;
						DoubleAnimation animation3 = new DoubleAnimation(fromValue, toValue, new Duration(TimeSpan.FromSeconds(duration)));

						fromValue = Canvas.GetTop(currentCard);
						toValue = fromValue - originalHeight / 2;
						DoubleAnimation animation4 = new DoubleAnimation(fromValue, toValue, new Duration(TimeSpan.FromSeconds(duration)));

						currentCard.BeginAnimation(FrameworkElement.HeightProperty, animation3);
						currentCard.BeginAnimation(Canvas.TopProperty, animation4);
					};

					currentCard.BeginAnimation(FrameworkElement.HeightProperty, animation1);
					currentCard.BeginAnimation(Canvas.TopProperty, animation2);
				} break;

				case Key.Down:
				{
					currentCard.RenderTransformOrigin = new Point(0.5, 0.5);
					ScaleTransform transform = new ScaleTransform();
					transform.ScaleY = 1;
					currentCard.RenderTransform = transform;

					DoubleAnimation da = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(1)));
					da.AutoReverse = true;

					transform.BeginAnimation(ScaleTransform.ScaleXProperty, da);
				} break;

				default:
				{
				} break;
			}

			//e.Handled = true;
		}

		void animation1_Completed(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
