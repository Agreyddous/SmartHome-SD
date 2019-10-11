using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Domain.SmartContext.Models
{
	public class SmartObjectExecutionResult : Notifiable
	{
		public SmartObjectExecutionResult(string result = "") => Result = result;

		public string Result { get; private set; }
	}
}