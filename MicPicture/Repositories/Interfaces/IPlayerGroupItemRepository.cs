using MicPicture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicPicture.Repositories.Interfaces
{
	public interface IPlayerGroupItemRepository
	{
		List<PlayerGroupItem> DbGetPlayerScores(int playerID);
        PlayerGroupItem DbPlayerGroupItemInsert(int playerId, int scoreID);
		
	}
}
