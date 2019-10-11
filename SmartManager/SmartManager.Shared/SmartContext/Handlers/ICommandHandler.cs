using SmartManager.Shared.SmartShared.Commands;
using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Shared.SmartShared.Handlers
{
	public interface ICommandHandler<T, E> : INotifiable where T : ICommand
	{
		E Handle(T command);
	}
}