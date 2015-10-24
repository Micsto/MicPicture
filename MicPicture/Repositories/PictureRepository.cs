using MicPicture.Model;
using System;
using System.Collections.Generic;
using System.Data;
using MicPicture.Repositories.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicPicture.Repositories
{
	public class PictureRepository : GenericRepository<Picture>, IPictureRepository
	{
		public List<Picture> DbGetallPictures(int pictureParent)
		{
			return GetList("uspViewAllPictures", new Dictionary<string, Tuple<SqlDbType, object>>()
			{
				{"@PictureParent", new Tuple<SqlDbType, object>(SqlDbType.Int, pictureParent)}
			});
		}

	}
}
