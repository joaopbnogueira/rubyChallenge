namespace Cabify.Storefront.Services
{
    public interface IUserContext
    {
        string Name { get; }
        string ImageUrl { get; }
        string Email { get; }
    }
}
