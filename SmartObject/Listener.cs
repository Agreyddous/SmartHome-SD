using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartObject.Enums;
using SmartObject.SmartObjects;

namespace SmartObject
{
	public class Listener
	{
		public void Listen(IPAddress address, int port, SmartThing smartThing)
		{
			try
			{
				TcpListener server = new TcpListener(address, port);
				server.Start();

				byte[] bytes = new Byte[256];
				string data = null;

				Console.Clear();

				while (true)
				{
					Console.WriteLine("Waiting for an action...");

					TcpClient client = server.AcceptTcpClient();
					Console.WriteLine("Finally! An Action!");

					data = null;

					NetworkStream stream = client.GetStream();

					int i;

					while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
					{
						data = Encoding.ASCII.GetString(bytes, 0, i);
						ESmartCommands command = JsonConvert.DeserializeObject<ESmartCommands>(data);

						string response = smartThing.Execute(command);

						byte[] msg = Encoding.ASCII.GetBytes(response);

						stream.Write(msg, 0, msg.Length);
					}

					client.Close();
				}
			}
			catch
			{
				Console.WriteLine("something went wrong...");
			}
		}
	}
}