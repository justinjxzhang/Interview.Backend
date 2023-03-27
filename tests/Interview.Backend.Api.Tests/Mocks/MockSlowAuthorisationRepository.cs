using Interview.Backend.Data.Models;

namespace Interview.Backend.Api.Tests;

public class MockSlowAuthorisationRepository : IAuthorisationRepository
{
    private readonly Dictionary<Guid, Guid[]> companyAuthorised = new Dictionary<Guid, Guid[]>() {
        {
            Guid.Parse("867bbfe2-2024-4580-98c3-0c6bc716e038"),
            new [] {
                Guid.Parse("e6b990b1-82d2-4ed7-b1b5-5a5cf6277d1d"),
                Guid.Parse("0d86e084-f69d-4911-95f6-0c917a088f61"),
                Guid.Parse("03659bb5-27d1-4587-a59e-3bbc2644a5a2")
            }
        }
    };

    public async Task<bool> UserAuthorisedForCompany(Guid userId, Guid companyId)
    {
        await Task.Delay(200);
        return this.companyAuthorised[companyId].Any(x => x == userId);
    }
}