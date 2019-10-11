using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using SmartManager.Domain.SmartContext.Models;
using SmartManager.Domain.SmartContext.Services;
using SmartManager.Shared.SmartShared.Enums;
using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Infra.SmartContext.Services
{
	public class SmartObjectCommunicationService : Notifiable, ISmartObjectCommunicationService
	{
		public SmartObjectExecutionResult Execute(string ipAddress, int port, ESmartCommands command)
		{
			SmartObjectExecutionResult result = new SmartObjectExecutionResult();

			try
			{
				TcpClient client = new TcpClient(ipAddress, port);

				byte[] data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(((int)command).ToString()));

				NetworkStream stream = client.GetStream();
				stream.Write(data, 0, data.Length);

				data = new Byte[256];
				string responseData = string.Empty;

				int bytes = stream.Read(data, 0, data.Length);
				responseData = Encoding.ASCII.GetString(data, 0, bytes);

				stream.Close();
				client.Close();

				result = new SmartObjectExecutionResult(responseData);
			}
			catch (Exception e)
			{
				AddNotification("Error", e.Message);
			}

			return result;
		}
	}
}