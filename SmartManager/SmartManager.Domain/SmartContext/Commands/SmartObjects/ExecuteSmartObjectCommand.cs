using System;
using SmartManager.Shared.SmartShared.Commands;
using SmartManager.Shared.SmartShared.Enums;

namespace SmartManager.Domain.SmartContext.Commands.SmartObjects
{
	public class ExecuteSmartObjectCommand : ICommand
	{
		public ESmartCommands Action { get; set; }

		public string SmartObjectId { get; private set; }

		public void SetSmartObjectId(string smartObjectId) => SmartObjectId = smartObjectId;
	}
}