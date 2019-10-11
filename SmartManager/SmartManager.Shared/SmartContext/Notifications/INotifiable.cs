using System.Collections.Generic;

namespace SmartManager.Shared.SmartShared.Notifications
{
	public interface INotifiable
	{
		bool Valid { get; }
		IList<Notification> Notifications { get; }
	}
}