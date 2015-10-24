using MicPicture.Model;
using System.Collections.Generic;

namespace MicPicture.Repositories.Interfaces
{
	public interface IScoreRepository
	{
		List<Score> DbGetAllScores();
		Score DbScoreInsert(int userScore);

	}
}
