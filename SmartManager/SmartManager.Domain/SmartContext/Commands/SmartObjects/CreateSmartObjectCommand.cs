using SmartManager.Shared.SmartShared.Commands;

namespace SmartManager.Domain.SmartContext.Commands.SmartObjects
{
	public class CreateSmartObjectCommand : ICommand
	{
		public string IpAddress { get; set; }
		public int Port { get; set; }
	}
}