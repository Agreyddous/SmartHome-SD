using Microsoft.AspNetCore.Mvc;
using SmartManager.Domain.SmartContext.Commands.SmartObjects;
using SmartManager.Domain.SmartContext.Handlers;

namespace SmartManager.API.Controllers
{
	public class SmartObjectController : Controller
	{
		public SmartObjectController(SmartObjectCommandHandler handler) : base(handler) { }

		/// <summary>
		/// Create a new SmartObject
		/// </summary>
		///
		/// <param name="command">Command with the new SmartObject's data</param>
		///
		/// <response code="200">Returns the SmartObject's Id</response>
		/// <response code="400">Invalid request</response>
		/// <response code="500">Internal Server Error</response>
		[HttpPost]
		[Route("V1/SmartObjects")]
		public CreateSmartObjectCommandResult Create([FromBody] CreateSmartObjectCommand command)
		{
			if (command == null)
				command = new CreateSmartObjectCommand();

			return Execute<CreateSmartObjectCommand, CreateSmartObjectCommandResult>(command);
		}

		/// <summary>
		/// Executen an action on a SmartObject
		/// </summary>
		///
		/// <param name="smartObjectId">The SmartObject's Id</param>
		/// <param name="command">Command SmartObject's execution data</param>
		///
		/// <response code="200">Returns the execution's result</response>
		/// <response code="400">Invalid request</response>
		/// <response code="500">Internal Server Error</response>
		[HttpPost]
		[Route("V1/SmartObjects/{smartObjectId}")]
		public ExecuteSmartObjectCommandResult Execute(string smartObjectId, [FromBody] ExecuteSmartObjectCommand command)
		{
			if (command == null)
				command = new ExecuteSmartObjectCommand();

			command.SetSmartObjectId(smartObjectId);

			return Execute<ExecuteSmartObjectCommand, ExecuteSmartObjectCommandResult>(command);
		}
	}
}