using System.Collections.Generic;
using System.Net;
using MongoDB.Bson;
using SmartManager.Shared.SmartShared.Commands;
using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Domain.SmartContext.Commands.SmartObjects
{
	public class CreateSmartObjectCommandResult : CommandResult
	{
		public CreateSmartObjectCommandResult() : base() { }
		public CreateSmartObjectCommandResult(HttpStatusCode code) : base(code) { }
		public CreateSmartObjectCommandResult(HttpStatusCode code, IEnumerable<Notification> notifications) : base(code, notifications) { }

		public ObjectId Id { get; set; }
	}
}