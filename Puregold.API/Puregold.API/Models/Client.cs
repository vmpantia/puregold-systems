using Microsoft.EntityFrameworkCore;
using Puregold.API.Common;
using System.ComponentModel.DataAnnotations;

namespace Puregold.API.Models
{
    [PrimaryKey(nameof(InternalID), nameof(Account_InternalID), nameof(AccessKey))]
    public class Client
    {
        public Guid InternalID { get; set; }

        public Guid Account_InternalID { get; set; }

        public Guid AccessKey { get; set; }

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
