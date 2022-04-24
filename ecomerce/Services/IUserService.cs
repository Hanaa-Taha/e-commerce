namespace ecomerce.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}