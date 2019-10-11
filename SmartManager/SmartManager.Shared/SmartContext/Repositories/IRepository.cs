using System.Collections.Generic;
using MongoDB.Bson;
using SmartManager.Shared.SmartShared.Entities;
using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Shared.SmartShared.Repositories
{
	public interface IRepository<T> : INotifiable where T : Entity
	{
		bool Exists(ObjectId id);
		T Get(ObjectId id);
		IEnumerable<ObjectId> GetAll();
		T Create(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}