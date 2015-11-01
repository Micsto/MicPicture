using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MicPicture.Repositories.Interfaces;

namespace MicPicture.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : new()
	{

		private static readonly string ConnectionString = Properties.Settings.Default.MicPictureDB_ConnectionString;

		public List<T> GetList(string usp, Dictionary<string, Tuple<SqlDbType, object>> parameters)
		{
			using (var con = new SqlConnection(ConnectionString))
			{
				using (var cmd = new SqlCommand(usp, con) { CommandType = CommandType.StoredProcedure })
				{
					con.Open();
					if (parameters != null)
						foreach (var param in parameters)
							cmd.Parameters.Add(new SqlParameter(param.Key, param.Value.Item1) { Value = param.Value.Item2 });
					var reader = cmd.ExecuteReader();
					var dataTable = new DataTable();
					dataTable.Load(reader);
					var resultList = dataTable.AsEnumerable().ToList();
					var ret = new List<T>(resultList.Count);

					var catType = typeof(T).GetProperties();
					foreach (var row in resultList)
					{
						var catObj = new T();
						foreach (var prop in catType)
						{
							if (prop.CanWrite && prop.GetSetMethod(/*nonPublic*/ true).IsPublic && row.Table.Columns.Contains(prop.Name))
								prop.SetValue(catObj, row.IsNull(prop.Name) ? default(T) : row[prop.Name], null);
						}
						ret.Add(catObj);
					}
					return ret;
				}
			}
		}


		public T GetObject(string usp, Dictionary<string, Tuple<SqlDbType, object>> parameters)
		{
			using (var con = new SqlConnection(ConnectionString))
			{
				using (var cmd = new SqlCommand(usp, con) { CommandType = CommandType.StoredProcedure })
				{
					con.Open();
					if (parameters != null)
						foreach (var param in parameters)
							cmd.Parameters.Add(new SqlParameter(param.Key, param.Value.Item1) { Value = param.Value.Item2 });
					var reader = cmd.ExecuteReader();
					var dataTable = new DataTable();
					dataTable.Load(reader);
					var resultList = dataTable.AsEnumerable().ToList();

					var catType = typeof(T).GetProperties();
					foreach (var row in resultList)
					{
						var obj = new T();
						foreach (var prop in catType)
						{
							if (prop.CanWrite && prop.GetSetMethod(/*nonPublic*/ true).IsPublic && row.Table.Columns.Contains(prop.Name))
								prop.SetValue(obj, row.IsNull(prop.Name) ? default(T) : row[prop.Name], null);
						}
						return obj;
					}
					throw new Exception();
				}
			}
		}


	}
}
