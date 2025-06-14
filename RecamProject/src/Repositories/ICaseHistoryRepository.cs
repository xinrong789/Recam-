using RecamProject.Domain.Mongo;
namespace RecamProject.Repositories
{
    public interface ICaseHistoryRepository
    {
        // Define methods for case history operations
        Task AddAsync(CaseHistory caseHistory);
        Task<List<CaseHistory>> GetByListingCaseIdAsync(string listingCaseId);

    }
}