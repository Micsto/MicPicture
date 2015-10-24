using MicPicture.Model;
namespace MicPicture.Repositories.Interfaces
{
	public interface IPlayerRepository
	{
	   Player DbPlayerInsert(string playerAlias);
    }
}
