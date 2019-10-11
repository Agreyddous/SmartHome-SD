using SmartObject.Enums;

namespace SmartObject.SmartObjects
{
	public abstract class SmartThing
	{
		protected string defaultResult = "Can't do that...";

		public abstract string Execute(ESmartCommands command);
	}
}