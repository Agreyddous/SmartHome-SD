using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Shared.SmartShared.ValueObjects
{
	public abstract class ValueObject : Notifiable
	{
		protected string GetThisName() => this.GetType().Name;
	}
}