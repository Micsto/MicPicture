using MicPicture.Model;
using MicPicture.Repositories.Interfaces;
namespace MicPicture.Repositories
{
	public class PlayerRepositoryFile : IPlayerRepository
	{
		public Player DbPlayerInsert(string playerAlias)
		{
			System.IO.File.WriteAllText(@"C: \Users\miche\Desktop\Test.txt", playerAlias);
			return new Player();
		}

	}
}
