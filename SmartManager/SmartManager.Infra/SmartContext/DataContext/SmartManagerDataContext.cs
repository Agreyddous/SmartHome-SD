using MongoDB.Driver;
using SmartManager.Shared.SmartShared;

namespace SmartManager.Infra.SmartContext.DataContext
{
	public class SmartDataContext
	{
		public SmartDataContext() => Database = new MongoClient(Settings.ConnectionString).GetDatabase(Settings.DatabaseName);

		public IMongoDatabase Database { get; private set; }
	}
}