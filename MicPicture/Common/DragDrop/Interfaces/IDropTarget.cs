using MicPicture.Common.DragDrop;

namespace MicPicture.Common.DragDrop.Interfaces
{
	public interface IDropTarget
	{
		void DragOver(DropInfo dropInfo);
		void Drop(DropInfo dropInfo);
	}
}
