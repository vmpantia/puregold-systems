using Microsoft.EntityFrameworkCore;
using Puregold.API.Common;
using Puregold.API.Contractors;
using Puregold.API.DataAccess;
using Puregold.API.Exceptions;
using Puregold.API.Models;
using Puregold.API.Models.Request;

namespace Puregold.API.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly PuregoldDbContext _db;
        public UtilityService(PuregoldDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<bool> IsAccessKeyValid(Guid accessKey)
        {
            var client = await _db.Clients.Where(data => data.AccessKey == accessKey).FirstAsync();

            if (client == null)
                return false;

            return client.IsValid;
        }
    }
}
