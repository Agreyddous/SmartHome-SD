using System;
using SmartManager.Shared.SmartShared.Commands;
using SmartManager.Shared.SmartShared.Handlers;

namespace SmartManager.API.Controllers
{
	public abstract class Controller : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly dynamic _handler;

		public Controller(dynamic handler) => _handler = handler;

		protected E Execute<T, E>(T command) where T : ICommand where E : ICommandResult
		{
			Guid requestId = Guid.NewGuid();

			E result = new Handler(_handler).Handle<T, E>(command, requestId, HttpContext.User.Identity.Name, HttpContext.Connection.RemoteIpAddress.ToString()).Result;

			HttpContext.Response.StatusCode = (int)result.Code;

			return result;
		}
	}
}