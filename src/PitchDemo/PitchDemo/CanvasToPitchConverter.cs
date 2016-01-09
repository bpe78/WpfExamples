using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace PitchDemo
{
	[ValueConversion(typeof(MouseEventArgs), typeof(PitchPoint))]
	public class CanvasToPitchConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Canvas canvas = parameter as Canvas;
			if (canvas == null) throw new InvalidOperationException();

			MouseEventArgs pos = ((MouseEventArgs)value);
			if (pos == null) throw new InvalidOperationException();

			var point = pos.GetPosition(canvas);
			point.X = (1.2 * point.X) / canvas.ActualWidth - 0.1;
			point.Y = point.Y / canvas.ActualHeight;

			return new PitchPoint(point.X, point.Y);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
