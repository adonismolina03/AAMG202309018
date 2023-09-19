namespace AAMG202309018.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string userName);
    }
}
