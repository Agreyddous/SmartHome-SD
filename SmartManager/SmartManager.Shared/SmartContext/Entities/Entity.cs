using SmartManager.Shared.SmartShared.Notifications;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartManager.Shared.SmartShared.Entities
{
	public abstract class Entity : Notifiable
	{
		protected Entity()
		{
			Id = new ObjectId();
		}

		[BsonId]
		public ObjectId Id { get; protected set; }
	}
}