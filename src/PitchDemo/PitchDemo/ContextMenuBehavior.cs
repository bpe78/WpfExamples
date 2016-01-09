using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace PitchDemo
{
	public class ContextMenuBehavior : Behavior<Canvas>
	{
		protected override void OnAttached()
		{
			base.OnAttached();

			this.AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
		}

		void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ContextMenu ctx = this.CtxMenu;
			if (ctx != null)
			{
				var point = (PitchPoint)Converter.Convert(e, typeof(PitchPoint), this.AssociatedObject, System.Globalization.CultureInfo.CurrentCulture);
				MousePoint.X = point.X;
				MousePoint.Y = point.Y;
				ctx.PlacementTarget = this.AssociatedObject;
				ctx.Placement = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
				ctx.IsOpen = true;
			}
		}

		protected override void OnDetaching()
		{
			this.AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;

			base.OnDetaching();
		}

		#region Converter

		public IValueConverter Converter
		{
			get { return (IValueConverter)GetValue(ConverterProperty); }
			set { SetValue(ConverterProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Converter.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ConverterProperty = DependencyProperty.Register("Converter", typeof(IValueConverter), typeof(ContextMenuBehavior), new PropertyMetadata(null));

		#endregion

		#region MousePoint

		public PitchPoint MousePoint
		{
			get { return (PitchPoint)GetValue(MousePointProperty); }
			set { SetValue(MousePointProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MousePoint.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MousePointProperty = DependencyProperty.Register("MousePoint", typeof(PitchPoint), typeof(ContextMenuBehavior), new PropertyMetadata(null));

		#endregion

		#region ContextMenu

		public ContextMenu CtxMenu
		{
			get { return (ContextMenu)GetValue(CtxMenuProperty); }
			set { SetValue(CtxMenuProperty, value); }
		}

		// Using a DependencyProperty as the backing store for CtxMenu.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CtxMenuProperty = DependencyProperty.Register("CtxMenu", typeof(ContextMenu), typeof(ContextMenuBehavior), new PropertyMetadata(null));

		#endregion
	}

}
