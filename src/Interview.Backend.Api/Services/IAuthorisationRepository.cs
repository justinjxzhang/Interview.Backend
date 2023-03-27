namespace Interview.Backend.Api.Services;

public interface IAuthorisationRepository {
    Task<bool> UserAuthorisedForCompany(Guid userId, Guid companyId);
}