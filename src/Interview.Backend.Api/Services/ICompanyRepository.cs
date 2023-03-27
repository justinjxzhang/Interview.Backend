using Interview.Backend.Data.Models;

namespace Interview.Backend.Api.Services;

public interface ICompanyRepository {
    Task<Company> GetCompanyByIdAsync(Guid id);
}