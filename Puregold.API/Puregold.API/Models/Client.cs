using Microsoft.EntityFrameworkCore;
using Puregold.API.Common;
using System.ComponentModel.DataAnnotations;

namespace Puregold.API.Models
{
    [PrimaryKey(nameof(AccessKey), nameof(Account_InternalID))]
    public class Client
    {
        public Guid AccessKey { get; set; }

        public Guid Account_InternalID { get; set; }

        [Required, MaxLength(Constants.LENGTH_25)]
        public string IPAddress { get; set; }

        [Required, MaxLength(Constants.LENGTH_25)]
        public string Browser { get; set; }

        [Required, MaxLength(Constants.LENGTH_25)]
        public string WindowsVersion { get; set; }

        public bool IsValid { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
