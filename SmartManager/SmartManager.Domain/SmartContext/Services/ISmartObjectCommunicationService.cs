using MongoDB.Bson;
using SmartManager.Domain.SmartContext.Models;
using SmartManager.Shared.SmartShared.Enums;

namespace SmartManager.Domain.SmartContext.Services
{
	public interface ISmartObjectCommunicationService
	{
		SmartObjectExecutionResult Execute(string ipAddress, int port, ESmartCommands command);
	}
}