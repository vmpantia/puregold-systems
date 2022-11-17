using Microsoft.EntityFrameworkCore;
using Puregold.API.Common;
using System.ComponentModel.DataAnnotations;

namespace Puregold.API.Models
{
    [PrimaryKey(nameof(InternalID), nameof(AccountID))]
    public class Account
    {
        #region Account Credentials for Login
        [Required, MaxLength(Constants.LENGTH_CREDENTIAL)]
        public string AccountID { get; set; }

        [Required, MaxLength(Constants.LENGTH_CREDENTIAL)]
        public string Password { get; set; }
        #endregion

        #region Personal Information
        public Guid InternalID { get; set; }

        [Required, MaxLength(Constants.LENGTH_50)]
        public string FirstName { get; set; }

        [MaxLength(Constants.LENGTH_50)]
        public string MiddleName { get; set; }

        [Required, MaxLength(Constants.LENGTH_50)]
        public string LastName { get; set; }

        [Required, MaxLength(Constants.LENGTH_GENDER)]
        public string Gender { get; set; }

        [Required, MaxLength(Constants.LENGTH_CIVIL_STATUS)]
        public string CivilStatus { get; set; }

        public DateTime Birthdate { get; set; }

        [Required, MaxLength(Constants.LENGTH_100)]
        public string Address { get; set; }

        [Required, MaxLength(Constants.LENGTH_50)]
        public string EmailAddress { get; set; }

        [Required, MaxLength(Constants.LENGTH_CONTACT)]
        public string ContactNo { get; set; }
        #endregion

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
