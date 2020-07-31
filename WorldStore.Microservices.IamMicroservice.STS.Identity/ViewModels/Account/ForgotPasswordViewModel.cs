using System.ComponentModel.DataAnnotations;

namespace WorldStore.Microservices.IamMicroservice.STS.Identity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}






