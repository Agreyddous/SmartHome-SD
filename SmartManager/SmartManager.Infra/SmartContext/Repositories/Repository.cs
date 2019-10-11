using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartManager.Infra.SmartContext.DataContext;
using SmartManager.Shared.SmartShared.Entities;
using SmartManager.Shared.SmartShared.Repositories;
using SmartManager.Shared.SmartShared.Notifications;

namespace SmartManager.Infra.SmartContext.Repositories
{
	public class Repository<T> : Notifiable, IRepository<T> where T : Entity
	{
		protected readonly IMongoCollection<T> _collection;

		public Repository(string collectionName, SmartDataContext dataContext) => _collection = dataContext.Database.GetCollection<T>(collectionName);

		public T Create(T entity)
		{
			try
			{
				_collection.InsertOne(entity);
			}
			catch (Exception e)
			{
				AddNotification("Error", e.Message);
			}

			return entity;
		}

		public void Delete(T entity)
		{
			try
			{
				_collection.DeleteOne(collectionEntity => collectionEntity.Id == entity.Id);
			}
			catch (Exception e)
			{
				AddNotification("Error", e.Message);
			}
		}

		public bool Exists(ObjectId id)
		{
			bool result = false;

			try
			{
				result = _collection.Find<T>(entity => entity.Id == id).Any();
			}
			catch (Exception e)
			{
				AddNotification("Error", e.Message);
			}

			return result;
		}

		public T Get(ObjectId id)
		{
			T result = null;

			try
			{
				result = _collection.Find<T>(entity => entity.Id == id).FirstOrDefault();
			}
			catch (Exception e)
			{
				AddNotification("Error", e.Message);
			}

			return result;
		}

		public IEnumerable<ObjectId> GetAll()
		{
			IEnumerable<ObjectId> entities = new List<ObjectId>();

			try
			{
				entities = _collection.Find(entity => true).ToEnumerable().Select(entity => entity.Id);
			}
			catch (Exception e)
			{
				AddNotification("Error", e.Message);
			}

			return entities;
		}

		public void Update(T entity)
		{
			try
			{
				_collection.ReplaceOne(collectionEntity => collectionEntity.Id == entity.Id, entity);
			}
			catch (Exception e)
			{
				AddNotification("Error", e.Message);
			}
		}
	}
}