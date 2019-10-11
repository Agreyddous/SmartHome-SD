using SmartObject.Enums;

namespace SmartObject.SmartObjects
{
	public class SmartAirConfitioner : SmartThing
	{
		public override string Execute(ESmartCommands command)
		{
			string result = string.Empty;

			switch (command)
			{
				case ESmartCommands.On:
					result = "Air Conditioner turned on!";

					break;

				case ESmartCommands.Off:
					result = "Air Conditioner turned off!";

					break;

				case ESmartCommands.TemperatureUp:
					result = "Temperature went up!";

					break;

				case ESmartCommands.TemperatureDown:
					result = "Temperature went down!";

					break;

				default:
					result = defaultResult;

					break;
			}

			return result;
		}
	}
}