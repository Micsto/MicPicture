using MicPicture.Model;
using System.Collections.Generic;

namespace MicPicture.Repositories.Interfaces
{
	public interface IPictureRepository
	{
		List<Picture> DbGetallPictures(int pictureParent);
	}
}
