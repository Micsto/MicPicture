using MicPicture.Common;

namespace MicPicture.Model
{
	public class Score : MyExtansions
	{
		private int _scoreID;
		private int _userScore;

		public int ScoreID
		{
			get { return _scoreID; }
			set
			{
				_scoreID = value;
				OnPropertyChanged("ScoreID");
			}
		}
		public int UserScore
		{
			get { return _userScore; }
			set
			{
				_userScore = value;
				OnPropertyChanged("UserScore");
			}
		}
	}
}
