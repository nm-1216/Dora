

namespace Dora.ViewModels.AccountViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Domain.Entities.School;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class UserCreateViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public SchoolUser User { get; set; }
        [Display(Name = "用户角色")]
        public IEnumerable<IdentityRole> RoleList { get; set; }
        public IEnumerable<string> RoleListValue { get; set; }

        [Display(Name = "用户角色")]
        public IEnumerable<IdentityRole> RoleSelectList { get; set; }
        public IEnumerable<string> RoleSelectListValue { get; set; }
    }
}
