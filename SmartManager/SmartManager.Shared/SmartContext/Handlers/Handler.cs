using System;
using System.Threading.Tasks;
using SmartManager.Shared.SmartShared.Commands;
using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Shared.SmartShared.Handlers
{
	public class Handler : Notifiable
	{
		private readonly dynamic _handler;

		public Handler(dynamic handler) => _handler = handler;

		public async Task<E> Handle<T, E>(T command, Guid requestId, string user, string requestHost) where T : ICommand where E : ICommandResult
		{
			E result = (E)Activator.CreateInstance(typeof(E), false);

			try
			{
				var handleResult = _handler.Handle(command);

				if (handleResult.GetType().BaseType == typeof(Task<E>) || handleResult.GetType().BaseType == typeof(Task))
					result = await handleResult;

				else
					result = handleResult;
			}
			catch { }

			return result;
		}
	}
}