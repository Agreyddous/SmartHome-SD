using SmartManager.Shared.SmartShared.Entities;

namespace SmartManager.Domain.SmartContext.Entities
{
	public class SmartObject : Entity
	{
		protected SmartObject() { }

		public SmartObject(string ipAddress, int port)
		{
			IpAddress = ipAddress;
			Port = port;
		}

		public string IpAddress { get; private set; }
		public int Port { get; private set; }
	}
}