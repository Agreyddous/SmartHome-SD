using SmartObject.Enums;

namespace SmartObject.SmartObjects
{
	public class SmartTV : SmartThing
	{
		public override string Execute(ESmartCommands command)
		{
			string result = string.Empty;

			switch (command)
			{
				case ESmartCommands.On:
					result = "TV turned on!";

					break;

				case ESmartCommands.Off:
					result = "TV turned off!";

					break;

				case ESmartCommands.ChannelUp:
					result = "Channel went up!";

					break;

				case ESmartCommands.ChannelDown:
					result = "Channel went down!";

					break;

				default:
					result = defaultResult;

					break;
			}

			return result;
		}
	}
}