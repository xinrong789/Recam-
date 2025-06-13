using MongoDB.Driver;
using RecamProject.Settings;


using Microsoft.Extensions.Options;

namespace RecamProject.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDBSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        }

        // 定义每个 Collection 作为属性暴露出去
        // public IMongoCollection<LogEntry> Logs => _database.GetCollection<LogEntry>("Logs");

        // 你可以继续加其他 Collection：
        // public IMongoCollection<YourOtherEntity> YourOtherEntities => _database.GetCollection<YourOtherEntity>("YourOtherEntities");
    }
}
