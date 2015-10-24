using MicPicture.Common;
namespace MicPicture.Model
{
	public class Player : MyExtansions
	{
		private int _playerID;
		private string _playerAlias;
		public int PlayerID
		{
			get { return _playerID; }
			set
			{
				_playerID = value;
				OnPropertyChanged("PlayerID");
			}
		}
		public string PlayerAlias
		{
			get { return _playerAlias; }
			set
			{
				_playerAlias = value;
				OnPropertyChanged("PlayerAlias");
			}
		}
	}
}
