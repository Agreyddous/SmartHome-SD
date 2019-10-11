using System.Collections.Generic;
using System.Net;
using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Shared.SmartShared.Commands
{
	public interface ICommandResult
	{
		HttpStatusCode Code { get; }
		IEnumerable<Notification> Notifications { get; }
	}
}