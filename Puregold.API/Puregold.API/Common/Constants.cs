namespace Puregold.API.Common
{
    public class Constants
    {
        public const int LENGTH_CREDENTIAL = 15;
        public const int LENGTH_CONTACT = 15;
        public const int LENGTH_GENDER = 6;
        public const int LENGTH_CIVIL_STATUS = 15;
        public const int LENGTH_25 = 25;
        public const int LENGTH_50 = 50;
        public const int LENGTH_100 = 100;
        public const int LENGTH_MAX = 255;

        public const string ERROR_LOGIN_REQUEST_NULL = "Login Request must have value.";
        public const string ERROR_LOGIN_REQUEST_ACCOUNT_NOT_EXIST = "Account doesn't Exist in the System.";
        public const string ERROR_LOGIN_REQUEST_INCORRECT_PASSWORD = "Incorrect Password, Please try again.";
    }
}
