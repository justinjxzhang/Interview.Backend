using Interview.Backend.Data.Models;

namespace Interview.Backend.Api.Services;

public interface IUserRepository {
    Task<User> GetUserByIdAsync(Guid id);
    Task<User> AddUserAsync(string givenName, string familyName);
    Task DeleteUserAsync(Guid id);
}