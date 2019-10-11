using SmartObject.Enums;

namespace SmartObject.SmartObjects
{
	public class SmartLight : SmartThing
	{
		public override string Execute(ESmartCommands command)
		{
			string result = string.Empty;

			switch (command)
			{
				case ESmartCommands.On:
					result = "Light turned on!";

					break;

				case ESmartCommands.Off:
					result = "Light turned off!";

					break;

				default:
					result = defaultResult;

					break;
			}

			return result;
		}
	}
}