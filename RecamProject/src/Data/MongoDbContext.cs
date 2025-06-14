using MongoDB.Driver;
using RecamProject.Settings;
using RecamProject.Domain.Mongo;


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

     public IMongoCollection<CaseHistory> CaseHistories => _database.GetCollection<CaseHistory>("CaseHistories");
    public IMongoCollection<UserActivityLog> UserActivityLogs => _database.GetCollection<UserActivityLog>("UserActivityLogs");
    }
}
