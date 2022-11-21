namespace Puregold.API.Models.Request
{
    public class AccountRequest
    {
        public string FunctionID { get; set; }
        public Client clientInfo { get; set; }
        public Account inputAccount { get; set; }
    }
}
