using Microsoft.EntityFrameworkCore;
using Puregold.API.Common;
using Puregold.API.Contractors;
using Puregold.API.DataAccess;
using Puregold.API.Exceptions;
using Puregold.API.Models;
using Puregold.API.Models.Request;

namespace Puregold.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly PuregoldDbContext _db;
        public AccountService(PuregoldDbContext dbContext)
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

        public async Task SaveAccount(AccountRequest request)
        {
            if (request == null)
                throw new ServiceException(Constants.ERROR_ACCOUNT_REQUEST_NULL);

            switch (request.FunctionID)
            {
                case "A":
                    await CreateAccount(request.inputAccount);
                    break;
                case "C":
                    await UpdateAccount(request.inputAccount);
                    break;
            }
            await _db.SaveChangesAsync();
        }

        private async Task CreateAccount(Account account)
        {
            //Create InternalID for New Account
            account.InternalID = Guid.NewGuid();
            account.CreatedDate = DateTime.Now;
            account.ModifiedDate = DateTime.Now;

            //Add New Account in Database
            await _db.Accounts.AddAsync(account);
        }

        private async Task UpdateAccount(Account account)
        {
            var currentAccount = await _db.Accounts.FindAsync(account.InternalID, account.AccountID);

            if (currentAccount == null)
                throw new ServiceException(Constants.ERROR_ACCOUNT_NOT_EXIST);

            //currentAccount.AccountID = account.AccountID;
            currentAccount.Password = account.Password;
            //currentAccount.InternalID = account.InternalID;
            currentAccount.FirstName = account.FirstName;
            currentAccount.MiddleName = account.MiddleName;
            currentAccount.LastName = account.LastName;
            currentAccount.Gender = account.Gender;
            currentAccount.CivilStatus = account.CivilStatus;
            currentAccount.Birthdate = account.Birthdate;
            currentAccount.Address = account.Address;
            currentAccount.EmailAddress = account.EmailAddress;
            currentAccount.ContactNo = account.ContactNo;
            //currentAccount.CreatedDate = account.CreatedDate;
            currentAccount.ModifiedDate = DateTime.Now;
        }
    }
}
