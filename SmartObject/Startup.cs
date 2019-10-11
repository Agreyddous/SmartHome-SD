using System;
using System.Net;
using SmartObject.SmartObjects;

namespace SmartObject
{
	public class Startup
	{
		public void Start()
		{
			Console.WriteLine("Starting smartobject...");

			Console.WriteLine("What is my Address?");

			Console.Write("-> ");
			string address = Console.ReadLine();

			IPAddress ipAddress;

			if (!string.IsNullOrEmpty(address) && IPAddress.TryParse(address, out ipAddress))
			{
				Console.WriteLine("What is my port?");

				Console.Write("-> ");
				string portStr = Console.ReadLine();

				int port = 0;

				if (!string.IsNullOrEmpty(portStr) && int.TryParse(portStr, out port))
				{

					if (SmartManagerService.Register(address, port))
					{
						Console.WriteLine("Choose my type:");
						Console.WriteLine("1 - TV");
						Console.WriteLine("2 - Air Conditioner");
						Console.WriteLine("3 - Light");
						Console.WriteLine("4 - Water heater");
						Console.WriteLine("5 - Lock");

						Console.Write("->");
						string type = Console.ReadLine();

						SmartThing smartThing = null;

						switch (type)
						{
							case "1":
								smartThing = new SmartTV();

								break;

							case "2":
								smartThing = new SmartAirConfitioner();

								break;

							case "3":
								smartThing = new SmartLight();

								break;

							case "4":
								smartThing = new SmartWaterHeater();

								break;

							case "5":
								smartThing = new SmartLock();

								break;

							default:
								Console.WriteLine("Invalid choice...");

								break;
						}

						if (smartThing != null)
							new Listener().Listen(ipAddress, port, smartThing);
					}

					else
						Console.WriteLine("Sorry... Could not register myself to the manager...");
				}

				else
					Console.WriteLine("Port not valid...");

			}

			else
				Console.WriteLine("Invalid address...");

			Console.WriteLine("Smart object shutting down...");
		}
	}
}