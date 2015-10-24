using MicPicture.Common;

namespace MicPicture.Model
{
	public class PlayerGroupItem : MyExtansions
	{
		private int _playerGroupItemID;
		private int _playerID;
		private int _scoreID;

		public int PlayerGroupItemID
		{
			get { return _playerGroupItemID; }
			set
			{
				_playerGroupItemID = value;
				OnPropertyChanged("PlayerGroupItemID");
			}
		}
		public int PlayerID
		{
			get { return _playerID; }
			set
			{
				_playerID = value;
				OnPropertyChanged("PlayerID");
			}
		}
		public int ScoreID
		{
			get { return _scoreID; }
			set
			{
				_scoreID = value;
				OnPropertyChanged("ScoreID");
			}
		}
	}
}
