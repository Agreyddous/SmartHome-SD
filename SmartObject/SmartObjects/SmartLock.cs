using SmartObject.Enums;

namespace SmartObject.SmartObjects
{
	public class SmartLock : SmartThing
	{
		public override string Execute(ESmartCommands command)
		{
			string result = string.Empty;

			switch (command)
			{
				case ESmartCommands.Lock:
					result = "Locked!";

					break;

				case ESmartCommands.Unlock:
					result = "Unlocked!";

					break;

				default:
					result = defaultResult;

					break;
			}

			return result;
		}
	}
}