using System.ComponentModel;

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
	}
}
