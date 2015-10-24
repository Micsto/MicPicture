using System;
using System.Collections.Generic;
using System.Data;
using MicPicture.Model;
using MicPicture.Repositories.Interfaces;


namespace MicPicture.Repositories
{
	public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
	{
		public Player DbPlayerInsert(string playerAlias)
		{
			return GetObject("uspPlayerInsert", new Dictionary<string, Tuple<SqlDbType, object>>()
			{
				{"@PlayerAlias", new Tuple<SqlDbType, object>(SqlDbType.VarChar, playerAlias)}
			});
		}

	}
}
