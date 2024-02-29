using System.ComponentModel.DataAnnotations;

namespace IdentityManager.Models
{
    public class VerifyAuthenticatorViewModel
    {
        [Required]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
