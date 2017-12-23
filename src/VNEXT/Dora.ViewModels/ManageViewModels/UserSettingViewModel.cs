namespace Dora.ViewModels.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class UserSettingViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "List Page Size")]
        public int PageSize { get; set; }
    }
}
