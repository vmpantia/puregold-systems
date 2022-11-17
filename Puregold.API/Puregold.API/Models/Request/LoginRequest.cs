namespace Puregold.API.Models.Request
{
    public class LoginRequest
    {
        public string AccountID { get; set; }
        public string Password { get; set; }
        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public string WindowsVersion { get; set; }
    }
}
