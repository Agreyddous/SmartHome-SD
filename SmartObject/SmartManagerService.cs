using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SmartObject
{
	public static class SmartManagerService
	{
		public static bool Register(string address, int port)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:5000");

			JObject content = new JObject();
			content["ipAddress"] = address;
			content["port"] = port;

			HttpResponseMessage response = client.PostAsync("/V1/SmartObjects", new StringContent(content.ToString(), Encoding.Default, "application/json")).Result;

			if (response.IsSuccessStatusCode)
				Console.WriteLine(response.Content.ReadAsStringAsync().Result);

			return response.IsSuccessStatusCode;
		}
	}
}