using MicPicture.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MicPicture.Common
{
	public abstract class MyExtansions : INotifyPropertyChanged
	{
		protected MyExtansions() { }

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				var e = new PropertyChangedEventArgs(propertyName);
				handler(this, e);
			}
		}

		public static void Shuffle<T>(ObservableCollection<T> observableCollection)
		{
			int n = observableCollection.Count;
			Random rnd = new Random();
			while (n > 1)
			{
				int k = (rnd.Next(0, n) % n);
				n--;
				T value = observableCollection[k];
				observableCollection[k] = observableCollection[n];
				observableCollection[n] = value;
			}
		}



	

	}
}
