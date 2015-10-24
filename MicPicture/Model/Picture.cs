using MicPicture.Common;

namespace MicPicture.Model
{
	public class Picture : MyExtansions
	{
		private int _pictureID;
		private byte[] _pictures;
		private int _pictureParent;

		public int PictureID
		{
			get { return _pictureID; }
			set
			{
				_pictureID = value;
				OnPropertyChanged("PictureID");
			}
		}
		public byte[] Pictures
		{
			get { return _pictures; }
			set
			{
				_pictures = value;
				OnPropertyChanged("Pictures");
			}
		}

		public int PictureParent
		{
			get { return _pictureParent; }
			set
			{
				_pictureParent = value;
				OnPropertyChanged("PictureParemt");
			}
		}
	}
}
