using System.Collections.Generic;
using System.Net;
using SmartManager.Shared.SmartShared.Commands;
using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Domain.SmartContext.Commands.SmartObjects
{
	public class ExecuteSmartObjectCommandResult : CommandResult
	{
		public ExecuteSmartObjectCommandResult() : base() { }
		public ExecuteSmartObjectCommandResult(HttpStatusCode code) : base(code) { }
		public ExecuteSmartObjectCommandResult(HttpStatusCode code, IEnumerable<Notification> notifications, string result = null) : base(code, notifications)
		{
			Result = result;
		}

		public string Result { get; private set; }
	}
}