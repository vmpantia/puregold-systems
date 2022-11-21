
namespace Puregold.API.Contractors
{
    public interface IUtilityService
    {
        Task<bool> IsAccessKeyValid(Guid accessKey);
    }
}