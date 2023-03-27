using Interview.Backend.Data.Models;

namespace Interview.Backend.Api.Tests;

public class MockSlowCompanyRepository : ICompanyRepository
{
    private readonly List<Company> companies = new List<Company>() {
        new Company() { Id = Guid.Parse("867bbfe2-2024-4580-98c3-0c6bc716e038"), Name = "Company0" },
        new Company() { Id = Guid.Parse("d663ada5-e4a4-4a60-8f2b-71cf79e21b02"), Name = "Company1" },
        new Company() { Id = Guid.Parse("a4fb31ab-90c1-465c-b396-2b340377d86b"), Name = "Company2" },
    };

    public async Task<Company> GetCompanyByIdAsync(Guid id)
    {
        await Task.Delay(7500);
        return this.companies.FirstOrDefault(x => x.Id == id);
    }
}