using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace PitchDemo
{
	public class EventToCommand : TriggerAction<DependencyObject>
	{
		protected override void Invoke(object parameter)
		{
			if (base.AssociatedObject != null)
			{
				if (Command != null)
				{
					PitchPoint point = null;
					if (Converter != null)
						point = (PitchPoint)Converter.Convert(parameter, parameter.GetType(), AssociatedObject, System.Globalization.CultureInfo.CurrentCulture); 

					if(Command.CanExecute(point))
						Command.Execute(point);
				}
			}
		}

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(EventToCommand), new UIPropertyMetadata(null));


		public object CommandParameter
		{
			get { return (object)GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		// Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(EventToCommand), new PropertyMetadata(0));


		public IValueConverter Converter
		{
			get { return (IValueConverter)GetValue(ConverterProperty); }
			set { SetValue(ConverterProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Converter.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ConverterProperty =
				DependencyProperty.Register("Converter", typeof(IValueConverter), typeof(EventToCommand), new PropertyMetadata(null));
	}
}
