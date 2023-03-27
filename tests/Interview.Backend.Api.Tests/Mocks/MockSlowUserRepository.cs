using Interview.Backend.Data.Models;

namespace Interview.Backend.Api.Tests;

public class MockSlowUserRepository : IUserRepository
{
    private readonly List<User> users = new List<User>() {
        new User() { Id = Guid.Parse("e6b990b1-82d2-4ed7-b1b5-5a5cf6277d1d"), GivenName = "User0", FamilyName = "Test" },
        new User() { Id = Guid.Parse("0d86e084-f69d-4911-95f6-0c917a088f61"), GivenName = "User1", FamilyName = "Test" },
        new User() { Id = Guid.Parse("03659bb5-27d1-4587-a59e-3bbc2644a5a2"), GivenName = "User2", FamilyName = "Test" },
        new User() { Id = Guid.Parse("263cbe04-0b98-4839-88c1-5d23ebe70045"), GivenName = "User3", FamilyName = "Test" },
        new User() { Id = Guid.Parse("48ddaa3a-575c-4266-bbe6-e1e9a381aa09"), GivenName = "User4", FamilyName = "Test" },
        new User() { Id = Guid.Parse("f9d6f9c6-47ad-4cb7-b563-2a943c0003d8"), GivenName = "User5", FamilyName = "Test" },
        new User() { Id = Guid.Parse("9c4ce36a-8969-44a5-963d-509be77c9e72"), GivenName = "User6", FamilyName = "Test" },
        new User() { Id = Guid.Parse("c8b6e870-42a1-43f0-a66b-d57998fed06e"), GivenName = "User7", FamilyName = "Test" },
        new User() { Id = Guid.Parse("d2365c3f-3017-4ce8-804b-511f0e9eaf21"), GivenName = "User8", FamilyName = "Test" },
        new User() { Id = Guid.Parse("09eee869-1277-4a9a-a843-5909760385d3"), GivenName = "User9", FamilyName = "Test" }
    };


    public async Task<User> AddUserAsync(string givenName, string familyName)
    {
        await Task.Delay(7500);
        var newUser = new User() {
            Id = Guid.NewGuid(),
            GivenName = givenName,
            FamilyName= familyName
        };
        this.users.Add(newUser);
        return newUser;
    }

    public async Task DeleteUserAsync(Guid id)
    {
        await Task.Delay(7500);
        this.users.RemoveAll(x => x.Id == id);
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        await Task.Delay(7500);
        return this.users.FirstOrDefault(x => x.Id == id);
    }
}