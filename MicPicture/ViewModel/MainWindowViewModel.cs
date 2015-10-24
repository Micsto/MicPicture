using MicPicture.Common;
using MicPicture.Repositories;
using MicPicture.Model;
using MicPicture.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;

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
		private ObservableCollection<Picture> _picturesToDrag;
		#endregion

		public ObservableCollection<Picture> PicturesToDrag
		{
			get { return _picturesToDrag; }
			set
			{
				_picturesToDrag = value;
				OnPropertyChanged("PictureToDrag");
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

			PicturesToDrag = new ObservableCollection<Picture>();
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
						var temp = PictureRepository.DbGetallPictures(1);
						foreach (var item in temp)
						{
							PicturesToDrag.Add(item);
						}
					}

				});
			}

		}

		#endregion
	}
}
