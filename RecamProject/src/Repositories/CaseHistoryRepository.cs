
using RecamProject.Data;

using RecamProject.Domain.Mongo;
using MongoDB.Driver;
namespace RecamProject.Repositories
{
    public class CaseHistoryRepository : ICaseHistoryRepository
    {
        private readonly IMongoCollection<CaseHistory> _caseHistoryCollection;

        public CaseHistoryRepository(MongoDbContext context)
        {
            _caseHistoryCollection = context.CaseHistories;
        }

        public async Task AddAsync(CaseHistory caseHistory)
        {
            await _caseHistoryCollection.InsertOneAsync(caseHistory);
        }

        public async Task<List<CaseHistory>> GetByListingCaseIdAsync(string listingCaseId)
        {
            return await _caseHistoryCollection
                .Find(ch => ch.ListingCaseId == listingCaseId)
                .ToListAsync();
        }

    }
}
