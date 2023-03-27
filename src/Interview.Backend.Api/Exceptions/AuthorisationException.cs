namespace Interview.Backend.Api.Exceptions;

public class AuthorisationException : Exception {

    public AuthorisationException(string message): base(message) {}
}