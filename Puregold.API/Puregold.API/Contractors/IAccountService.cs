using Puregold.API.Models;
using Puregold.API.Models.Request;

namespace Puregold.API.Contractors
{
    public interface IAccountService
    {
        Task<Client> LoginAsync(LoginRequest request);
        Task SaveAccount(AccountRequest request);
    }
}