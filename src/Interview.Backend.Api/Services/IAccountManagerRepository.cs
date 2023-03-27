using Interview.Backend.Data.Models;

namespace Interview.Backend.Api.Services;

public interface IAccountManagerRepository {
    Task<User?> GetAccountManagerAsync(Guid companyId);
}