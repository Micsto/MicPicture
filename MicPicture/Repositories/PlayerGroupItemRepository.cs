using MicPicture.Model;
using System;
using System.Collections.Generic;
using MicPicture.Repositories.Interfaces;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicPicture.Repositories
{
	public class PlayerGroupItemRepository : GenericRepository<PlayerGroupItem>, IPlayerGroupItemRepository
	{
		public List<PlayerGroupItem> DbGetPlayerScores(int playerID)
		{
			return GetList("uspViewPlayerScore", new Dictionary<string, Tuple<SqlDbType, object>>()
			{
				{ "@PlayerID", new Tuple<SqlDbType, object>(SqlDbType.Int, playerID) }
			});
		}
		public PlayerGroupItem DbPlayerGroupItemInsert(int playerId, int scoreID)
		{
			return GetObject("uspPlayerGroupItemInsert", new Dictionary<string, Tuple<SqlDbType, object>>()
			{
				{"@PlayerID", new Tuple<SqlDbType, object>(SqlDbType.Int, playerId)},
				{"@ScoreID", new Tuple<SqlDbType, object>(SqlDbType.Int, scoreID)},
			});
		}
	}
}
