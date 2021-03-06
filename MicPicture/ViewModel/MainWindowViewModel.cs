﻿using MicPicture.Common;
using MicPicture.Repositories;
using MicPicture.Model;
using MicPicture.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using MicPicture.Common.DragDrop.Interfaces;
using MicPicture.Common.DragDrop;
using System.Windows;

namespace MicPicture.ViewModel
{
	public class MainWindowViewModel : MyExtansions, IDropTarget
	{
		#region Repositories
		private IPlayerRepository PlayerRepository;
		private IScoreRepository ScoreRepository;
		private IPictureRepository PictureRepository;
		private IPlayerGroupItemRepository PlayerGroupItemRepository;
		#endregion

		#region Private fields
		private Player _newplayer;
		private Picture _mainPicture;
		private DelegateCommand _startGameCommand;
		private DelegateCommand _logInCommand;
		private ObservableCollection<Picture> _picturesToDrag;
		private ObservableCollection<Picture> _listOfDraggedPictures;
		private bool _areYouLoggedIn = false;
		private bool _isPlayButtonEnabled = true;
		private string _gameTime;
		private int _gameScore;
		private bool _gameOver;

		#endregion

		public string GameTimer
		{
			get { return _gameTime; }
			set
			{
				_gameTime = value;
#if CS5
				OnPropertyChanged("GameTimer");
#else
				OnPropertyChanged(nameof(GameTimer));
#endif
			}

		}
		public int GameScore
		{
			get { return _gameScore; }
			set
			{
				_gameScore = value;
#if CS5
				OnPropertyChanged("GameScore");
#else
				OnPropertyChanged(nameof(GameScore));
#endif
			}
		}
		public bool AreYouLoggedIn
		{
			get { return _areYouLoggedIn; }
			set
			{
				_areYouLoggedIn = value;
#if CS5
				OnPropertyChanged("AreYouLoggedIn");
#else
				OnPropertyChanged(nameof(AreYouLoggedIn));
#endif
			}
		}
		public bool IsPlayButtonEnabled
		{
			get { return _isPlayButtonEnabled; }
			set
			{
				_isPlayButtonEnabled = value;
#if CS5
				OnPropertyChanged("IsPlayButtonEnabled");
#else
				OnPropertyChanged(nameof(IsPlayButtonEnabled));
#endif
			}
		}

		public bool Gameover
		{
			get { return _gameOver; }
			set
			{
				_gameOver = value;
#if CS5
				OnPropertyChanged("Gameover");
#else
				OnPropertyChanged(nameof(Gameover));
#endif
			}
		}

		public ObservableCollection<Picture> PicturesToDrag
		{
			get { return _picturesToDrag; }
			set
			{
				_picturesToDrag = value;
#if CS5
				OnPropertyChanged("PicturesToDrag");
#else
				OnPropertyChanged(nameof(PicturesToDrag));
#endif
			}
		}

		public ObservableCollection<Picture> ListOfDraggedPictures
		{
			get { return _listOfDraggedPictures; }
			set
			{
				_listOfDraggedPictures = value;
#if CS5
				OnPropertyChanged("ListOfDraggedPictures");
#else
				OnPropertyChanged(nameof(ListOfDraggedPictures));
#endif
			}
		}

		public Player NewPlayer
		{
			get { return _newplayer; }
			set
			{
				_newplayer = value;
#if CS5
				OnPropertyChanged("NewPlayer");
#else
				OnPropertyChanged(nameof(NewPlayer));
#endif
			}
		}


		public Picture MainPicture
		{
			get { return _mainPicture; }
			set
			{
				_mainPicture = value;
#if CS5
				OnPropertyChanged("MainPicture");
#else
				OnPropertyChanged(nameof(MainPicture));
#endif
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
						Random random = new Random();
						int randomNumber = random.Next(1, 3);


						List<Picture> tempPictureList = PictureRepository.DbGetallPictures(randomNumber);
						foreach (Picture item in tempPictureList)
						{
							PicturesToDrag.Add(item);
						}
						MainPicture = PicturesToDrag.First();
						PicturesToDrag.Remove(PicturesToDrag.First());
						Shuffle(PicturesToDrag);
						_timer.Start();
						IsPlayButtonEnabled = false;
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

		void IDropTarget.DragOver(DropInfo dropInfo)
		{
			if (dropInfo.Data is Picture)
			{
				dropInfo.Effects = DragDropEffects.Move;
			}
		}

		void IDropTarget.Drop(DropInfo dropInfo)
		{
			Picture picture = (Picture)dropInfo.Data;
			ListOfDraggedPictures.Add(picture);
			GameScore += 10;
			PicturesToDrag.Remove(picture);
		}

	}
}
