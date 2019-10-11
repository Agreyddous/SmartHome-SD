using System.ComponentModel;

namespace SmartManager.Shared.SmartShared.Enums
{
	public enum ENotifications
	{
		[Description("Is Not Greater Than")] NotGreaterThan,
		[Description("Is Not Greater Or Equal Than")] NotGreaterOrEqualsThan,
		[Description("Can't be null")] Null,
		[Description("Id is invalid")] InvalidId,
		[Description("Does not exist")] DoesNotExist
	}
}