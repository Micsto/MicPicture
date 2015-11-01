using MicPicture.Common.DragDrop.Interfaces;
using MicPicture.Common.DragDrop.Utilities;
using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MicPicture.Common.DragDrop
{
	public static class DragDrop
	{

		public static bool GetIsDragSource(UIElement target)
		{
			return (bool)target.GetValue(IsDragSourceProperty);
		}

		public static void SetIsDragSource(UIElement target, bool value)
		{
			target.SetValue(IsDragSourceProperty, value);
		}

		public static bool GetIsDropTarget(UIElement target)
		{
			return (bool)target.GetValue(IsDropTargetProperty);
		}

		public static void SetIsDropTarget(UIElement target, bool value)
		{
			target.SetValue(IsDropTargetProperty, value);
		}

		public static IDragSource GetDragHandler(UIElement target)
		{
			return (IDragSource)target.GetValue(DragHandlerProperty);
		}

		public static void SetDragHandler(UIElement target, IDragSource value)
		{
			target.SetValue(DragHandlerProperty, value);
		}

		public static IDropTarget GetDropHandler(UIElement target)
		{
			return (IDropTarget)target.GetValue(DropHandlerProperty);
		}

		public static void SetDropHandler(UIElement target, IDropTarget value)
		{
			target.SetValue(DropHandlerProperty, value);
		}

		public static IDragSource DefaultDragHandler
		{
			get
			{
				if (m_DefaultDragHandler == null)
				{
					m_DefaultDragHandler = new DefaultDragHandler();
				}

				return m_DefaultDragHandler;
			}
			set
			{
				m_DefaultDragHandler = value;
			}
		}

		public static IDropTarget DefaultDropHandler
		{
			get
			{
				if (m_DefaultDropHandler == null)
				{
					m_DefaultDropHandler = new DefaultDropHandler();
				}

				return m_DefaultDropHandler;
			}
			set
			{
				m_DefaultDropHandler = value;
			}
		}

		public static readonly DependencyProperty DragHandlerProperty =
			DependencyProperty.RegisterAttached("DragHandler", typeof(IDragSource), typeof(DragDrop));

		public static readonly DependencyProperty DropHandlerProperty =
			DependencyProperty.RegisterAttached("DropHandler", typeof(IDropTarget), typeof(DragDrop));

		public static readonly DependencyProperty IsDragSourceProperty =
			DependencyProperty.RegisterAttached("IsDragSource", typeof(bool), typeof(DragDrop),
				new UIPropertyMetadata(false, IsDragSourceChanged));

		public static readonly DependencyProperty IsDropTargetProperty =
			DependencyProperty.RegisterAttached("IsDropTarget", typeof(bool), typeof(DragDrop),
				new UIPropertyMetadata(false, IsDropTargetChanged));

		static void IsDragSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			UIElement uiElement = (UIElement)d;

			if ((bool)e.NewValue == true)
			{
				uiElement.PreviewMouseLeftButtonDown += DragSource_PreviewMouseLeftButtonDown;
				uiElement.PreviewMouseLeftButtonUp += DragSource_PreviewMouseLeftButtonUp;
				uiElement.PreviewMouseMove += DragSource_PreviewMouseMove;
			}
			else
			{
				uiElement.PreviewMouseLeftButtonDown -= DragSource_PreviewMouseLeftButtonDown;
				uiElement.PreviewMouseLeftButtonUp -= DragSource_PreviewMouseLeftButtonUp;
				uiElement.PreviewMouseMove -= DragSource_PreviewMouseMove;
			}
		}

		static void IsDropTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			UIElement uiElement = (UIElement)d;

			if ((bool)e.NewValue == true)
			{
				uiElement.AllowDrop = true;
				uiElement.PreviewDragEnter += DropTarget_PreviewDragEnter;
				uiElement.PreviewDragOver += DropTarget_PreviewDragOver;
				uiElement.PreviewDrop += DropTarget_PreviewDrop;
			}
			else
			{
				uiElement.AllowDrop = false;
				uiElement.PreviewDragEnter -= DropTarget_PreviewDragEnter;
				uiElement.PreviewDragOver -= DropTarget_PreviewDragOver;
				uiElement.PreviewDrop -= DropTarget_PreviewDrop;
			}
		}


		static bool HitTestScrollBar(object sender, MouseButtonEventArgs e)
		{
			HitTestResult hit = VisualTreeHelper.HitTest((Visual)sender, e.GetPosition((IInputElement)sender));
			return hit.VisualHit.GetVisualAncestor<System.Windows.Controls.Primitives.ScrollBar>() != null;
		}

		static void Scroll(DependencyObject o, DragEventArgs e)
		{
			ScrollViewer scrollViewer = o.GetVisualDescendent<ScrollViewer>();

			if (scrollViewer != null)
			{
				Point position = e.GetPosition(scrollViewer);
				double scrollMargin = Math.Min(scrollViewer.FontSize * 2, scrollViewer.ActualHeight / 2);

				if (position.X >= scrollViewer.ActualWidth - scrollMargin &&
					scrollViewer.HorizontalOffset < scrollViewer.ExtentWidth - scrollViewer.ViewportWidth)
				{
					scrollViewer.LineRight();
				}
				else if (position.X < scrollMargin && scrollViewer.HorizontalOffset > 0)
				{
					scrollViewer.LineLeft();
				}
				else if (position.Y >= scrollViewer.ActualHeight - scrollMargin &&
					scrollViewer.VerticalOffset < scrollViewer.ExtentHeight - scrollViewer.ViewportHeight)
				{
					scrollViewer.LineDown();
				}
				else if (position.Y < scrollMargin && scrollViewer.VerticalOffset > 0)
				{
					scrollViewer.LineUp();
				}
			}
		}

		static void DragSource_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			// Ignore the click if the user has clicked on a scrollbar.
			if (HitTestScrollBar(sender, e))
			{
				m_DragInfo = null;
				return;
			}

			m_DragInfo = new DragInfo(sender, e);

			// If the sender is a list box that allows multiple selections, ensure that clicking on an 
			// already selected item does not change the selection, otherwise dragging multiple items 
			// is made impossible.
			ItemsControl itemsControl = sender as ItemsControl;

			if (m_DragInfo.VisualSourceItem != null && itemsControl != null && itemsControl.CanSelectMultipleItems())
			{
				IEnumerable selectedItems = itemsControl.GetSelectedItems();

				if (selectedItems.Cast<object>().Contains(m_DragInfo.SourceItem))
				{
					// TODO: Re-raise the supressed event if the user didn't initiate a drag.
					e.Handled = true;
				}
			}
		}

		static void DragSource_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (m_DragInfo != null)
			{
				m_DragInfo = null;
			}
		}

		static void DragSource_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			if (m_DragInfo != null)
			{
				Point dragStart = m_DragInfo.DragStartPosition;
				Point position = e.GetPosition(null);

				if (Math.Abs(position.X - dragStart.X) > SystemParameters.MinimumHorizontalDragDistance ||
					Math.Abs(position.Y - dragStart.Y) > SystemParameters.MinimumVerticalDragDistance)
				{
					IDragSource dragHandler = GetDragHandler(m_DragInfo.VisualSource);

					if (dragHandler != null)
					{
						dragHandler.StartDrag(m_DragInfo);
					}
					else
					{
						DefaultDragHandler.StartDrag(m_DragInfo);
					}

					if (m_DragInfo.Effects != DragDropEffects.None && m_DragInfo.Data != null)
					{
						DataObject data = new DataObject(m_Format.Name, m_DragInfo.Data);
						System.Windows.DragDrop.DoDragDrop(m_DragInfo.VisualSource, data, m_DragInfo.Effects);
						m_DragInfo = null;
					}
				}
			}
		}

		static void DropTarget_PreviewDragEnter(object sender, DragEventArgs e)
		{
			DropTarget_PreviewDragOver(sender, e);
		}

		static void DropTarget_PreviewDragOver(object sender, DragEventArgs e)
		{
			DropInfo dropInfo = new DropInfo(sender, e, m_DragInfo, m_Format.Name);
			IDropTarget dropHandler = GetDropHandler((UIElement)sender);

			if (dropHandler != null)
			{
				dropHandler.DragOver(dropInfo);
			}
			else
			{
				DefaultDropHandler.DragOver(dropInfo);
			}


			e.Effects = dropInfo.Effects;
			e.Handled = true;

			Scroll((DependencyObject)sender, e);
		}

		static void DropTarget_PreviewDrop(object sender, DragEventArgs e)
		{
			DropInfo dropInfo = new DropInfo(sender, e, m_DragInfo, m_Format.Name);
			IDropTarget dropHandler = GetDropHandler((UIElement)sender);

			if (dropHandler != null)
			{
				dropHandler.Drop(dropInfo);
			}
			else
			{
				DefaultDropHandler.Drop(dropInfo);
			}

			e.Handled = true;
		}



		static IDragSource m_DefaultDragHandler;
		static IDropTarget m_DefaultDropHandler;
		static DragInfo m_DragInfo;
		static DataFormat m_Format = DataFormats.GetDataFormat("MicPicture.Common.DragDrop");
	}
}
