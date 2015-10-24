using System;
using System.Collections.Generic;
using System.Data;
namespace MicPicture.Repositories.Interfaces
{
	public interface IGenericRepository <T> where T : new()
	{
		List<T> GetList(string usp, Dictionary<string, Tuple<SqlDbType, object>> parameters = null);

		T GetObject(string usp, Dictionary<string, Tuple<SqlDbType, object>> parameters = null);
    }
}
