using System.Net;
using MongoDB.Bson;
using SmartManager.Domain.SmartContext.Commands.SmartObjects;
using SmartManager.Domain.SmartContext.Entities;
using SmartManager.Domain.SmartContext.Models;
using SmartManager.Domain.SmartContext.Repositories;
using SmartManager.Domain.SmartContext.Services;
using SmartManager.Shared.SmartShared.Commands;
using SmartManager.Shared.SmartShared.Enums;
using SmartManager.Shared.SmartShared.Handlers;
using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Domain.SmartContext.Handlers
{
	public class SmartObjectCommandHandler : Notifiable,
											ICommandHandler<CreateSmartObjectCommand, CreateSmartObjectCommandResult>,
											ICommandHandler<ExecuteSmartObjectCommand, ExecuteSmartObjectCommandResult>
	{
		private readonly ISmartObjectRepository _smartObjectRepository;
		private readonly ISmartObjectCommunicationService _smartObjectCommunicationService;

		public SmartObjectCommandHandler(ISmartObjectRepository smartObjectRepository, ISmartObjectCommunicationService smartObjectCommunicationService)
		{
			_smartObjectRepository = smartObjectRepository;
			_smartObjectCommunicationService = smartObjectCommunicationService;
		}

		public CreateSmartObjectCommandResult Handle(CreateSmartObjectCommand command)
		{
			CreateSmartObjectCommandResult result = new CreateSmartObjectCommandResult();

			if (string.IsNullOrEmpty(command.IpAddress))
				AddNotification(nameof(command.IpAddress), ENotifications.Null);

			if (Valid)
			{
				SmartObject smartObject = new SmartObject(command.IpAddress, command.Port);

				_smartObjectRepository.Create(smartObject);

				if (_smartObjectRepository.Valid)
					result = new CreateSmartObjectCommandResult(HttpStatusCode.OK).Build<SmartObject, CreateSmartObjectCommandResult>(smartObject);
			}

			else
				result = new CreateSmartObjectCommandResult(HttpStatusCode.BadRequest, Notifications);

			return result;
		}

		public ExecuteSmartObjectCommandResult Handle(ExecuteSmartObjectCommand command)
		{
			ExecuteSmartObjectCommandResult result = new ExecuteSmartObjectCommandResult();

			ObjectId smartObjectId = new ObjectId();

			if (string.IsNullOrEmpty(command.SmartObjectId) || !ObjectId.TryParse(command.SmartObjectId, out smartObjectId))
				AddNotification(nameof(command.SmartObjectId), ENotifications.InvalidId);

			if (Valid)
			{
				SmartObject smartObject = _smartObjectRepository.Get(smartObjectId);

				if (smartObject == null && _smartObjectRepository.Valid)
					AddNotification(nameof(smartObject), ENotifications.DoesNotExist);

				if (Valid)
				{
					SmartObjectExecutionResult executionResult = _smartObjectCommunicationService.Execute(smartObject.IpAddress, smartObject.Port, command.Action);

					if (executionResult.Valid)
						result = new ExecuteSmartObjectCommandResult(HttpStatusCode.OK, Notifications, executionResult.Result);
				}

				else
					result = new ExecuteSmartObjectCommandResult(HttpStatusCode.BadRequest, Notifications);
			}

			else
				result = new ExecuteSmartObjectCommandResult(HttpStatusCode.BadRequest, Notifications);

			return result;
		}
	}
}
