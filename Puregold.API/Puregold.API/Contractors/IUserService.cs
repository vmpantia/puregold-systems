using Puregold.API.Models;
using Puregold.API.Models.Request;

namespace Puregold.API.Contractors
{
    public interface IUserService
    {
        Task<Client> LoginAsync(LoginRequest request);
    }
}