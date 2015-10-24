using MicPicture.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicPicture.Repositories.Interfaces;
namespace MicPicture.Repositories
{
	public class ScoreRepository : GenericRepository<Score>, IScoreRepository
	{

		public List<Score> DbGetAllScores()
		{
			return GetList("uspViewAllScores", new Dictionary<string, Tuple<SqlDbType, object>>());
		}

		public Score DbScoreInsert(int userScore)
		{
			return GetObject("uspScoreInsert", new Dictionary<string, Tuple<SqlDbType, object>>()
			{
				{"@UserScore", new Tuple<SqlDbType, object>(SqlDbType.Int, userScore)}
			});
		}


	}
}
