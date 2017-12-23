namespace Dora.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    //public class LoginViewModel
    //{
    //    [Required]
    //    [EmailAddress]
    //    public string Email { get; set; }

    //    [Required]
    //    [DataType(DataType.Password)]
    //    public string Password { get; set; }

    //    [Display(Name = "Remember me?")]
    //    public bool RememberMe { get; set; }
    //}

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string Uname { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
