using MicPicture.Model;
using MicPicture.ViewModel;
using System;
using MicPicture.Common;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MicPicture
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainWindowViewModel();
		}


	}
}
