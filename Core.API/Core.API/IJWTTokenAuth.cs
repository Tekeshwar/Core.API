namespace Core.API
{
    public interface IJWTTokenAuth
    {
        string Authenticate(string username, string password);
    }
}
