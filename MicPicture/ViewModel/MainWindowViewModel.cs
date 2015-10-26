using MicPicture.Common;
using MicPicture.Repositories;
using MicPicture.Model;
using MicPicture.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System;

namespace MicPicture.ViewModel
{
	public class MainWindowViewModel : MyExtansions
	{
		#region Repositories
		private IPlayerRepository PlayerRepository;
		private IScoreRepository ScoreRepository;
		private IPictureRepository PictureRepository;
		private IPlayerGroupItemRepository PlayerGroupItemRepository;
		#endregion

		#region Private properties

		private Player _newplayer;
		private DelegateCommand _startGameCommand;
		private DelegateCommand _logInCommand;
		private ObservableCollection<Picture> _picturesToDrag;
		private ObservableCollection<Picture> _listOfDraggedPictures;
		private bool _areYouLoggedIn = false;
		private string _gameTime;
		private string _gameScore;
		private bool _gameOver;

		#endregion

		public string GameTimer
		{
			get { return _gameTime; }
			set
			{
				_gameTime = value;
				OnPropertyChanged("GameTimer");
			}

		}
		public string GameScore
		{
			get { return _gameScore; }
			set
			{
				_gameScore = value;
				OnPropertyChanged("GameScore");
			}
		}
		public bool AreYouLoggedIn
		{
			get { return _areYouLoggedIn; }
			set
			{
				_areYouLoggedIn = value;
				OnPropertyChanged("AreYouLoggedIn");
			}
		}

		public bool Gameover
		{
			get { return _gameOver; }
			set
			{
				_gameOver = value;
				OnPropertyChanged("GameOver");
			}
		}

		public ObservableCollection<Picture> PicturesToDrag
		{
			get { return _picturesToDrag; }
			set
			{
				_picturesToDrag = value;
				OnPropertyChanged("PictureToDrag");
			}
		}

		public ObservableCollection<Picture> ListOfDraggedPictures
		{
			get { return _listOfDraggedPictures; }
			set
			{
				_listOfDraggedPictures = value;
				OnPropertyChanged("ListOfDraggedPictures");
			}
		}

		public Player NewPlayer
		{
			get { return _newplayer; }
			set
			{
				_newplayer = value;
				OnPropertyChanged("NewPlayer");
			}
		}



		public MainWindowViewModel()
		{
			PlayerRepository = new PlayerRepository();
			ScoreRepository = new ScoreRepository();
			PictureRepository = new PictureRepository();
			PlayerGroupItemRepository = new PlayerGroupItemRepository();
			NewPlayer = new Player();
			PicturesToDrag = new ObservableCollection<Picture>();
			ListOfDraggedPictures = new ObservableCollection<Picture>();

			_timer.Interval = new TimeSpan(0, 0, 1);
			_timer.Tick += new EventHandler(timer_Tick);
		}

		DispatcherTimer _timer = new DispatcherTimer();
		public int Currentsec = 60;

		private void timer_Tick(object sender, object e)
		{
			Currentsec = Currentsec - 1;
			GameTimer = Currentsec.ToString();
		}

		#region Commands

		public DelegateCommand StartGameCommand
		{
			get
			{
				return _startGameCommand ?? (_startGameCommand = new DelegateCommand
				{
					Execute = () =>
					{
						//var temp = PictureRepository.DbGetallPictures(1);
						//foreach (var item in temp)
						//{
						//	PicturesToDrag.Add(item);

						//}
						_timer.Start();
					}

				});
			}

		}
		public DelegateCommand LogInCommand
		{
			get
			{
				return _logInCommand ?? (_logInCommand = new DelegateCommand
				{
					Execute = () =>
					{
						PlayerRepository.DbPlayerInsert(NewPlayer.PlayerAlias);
						AreYouLoggedIn = true;
					}

				});
			}

		}

		#endregion
	}
}
