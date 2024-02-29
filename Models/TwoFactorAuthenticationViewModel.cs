namespace IdentityManager.Models
{
    public class TwoFactorAuthenticationViewModel
    {
        //Used to login
        public string Code { get; set; }

        //used to register
        public string Token { get; set; }
        public string? QRCodeUrl { get; set; }
    }
}
