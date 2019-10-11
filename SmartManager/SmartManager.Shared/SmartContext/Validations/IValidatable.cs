using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Shared.SmartShared.Validations
{
	public interface IValidatable : INotifiable
	{
		void Validate();
	}
}