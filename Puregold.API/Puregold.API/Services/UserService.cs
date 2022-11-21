using Microsoft.EntityFrameworkCore;
using Puregold.API.Common;
using Puregold.API.Contractors;
using Puregold.API.DataAccess;
using Puregold.API.Exceptions;
using Puregold.API.Models;
using Puregold.API.Models.Request;

namespace Puregold.API.Services
{
    public class UserService : IUserService
    {
        private readonly PuregoldDbContext _db;
        public UserService(PuregoldDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Client> LoginAsync(LoginRequest request)
        {
            if (request == null)
                throw new ServiceException(Constants.ERROR_LOGIN_REQUEST_NULL);

            //Check if AccountID Exist
            var accounts = await _db.Accounts.Where(data => data.AccountID == request.AccountID).ToListAsync();

            if (accounts == null || accounts.Count == 0)
                throw new ServiceException(Constants.ERROR_LOGIN_REQUEST_ACCOUNT_NOT_EXIST);

            //Check if Password is correct
            var account = accounts.Where(data => data.Password == request.Password).First();

            if (account == null)
                throw new ServiceException(Constants.ERROR_LOGIN_REQUEST_INCORRECT_PASSWORD);

            var client = await _db.Clients.Where(data => data.Account_InternalID == account.InternalID &&
                                                         (data.IsValid || data.EndDate < DateTime.Now)).FirstAsync();

            if (client != null)
            {
                return client;
            }

            client = new Client
            {
                AccessKey = Guid.NewGuid(),
                Account_InternalID = account.InternalID,
                IPAddress = request.IPAddress,
                Browser = request.Browser,
                WindowsVersion = request.WindowsVersion,
                IsValid = true,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1)
            };

            await _db.Clients.AddAsync(client);
            await _db.SaveChangesAsync();

            return client;
        }
    }
}
