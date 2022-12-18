using System.ComponentModel.DataAnnotations;

namespace SWMNU.NET.FlashMessage.TestingApp.Models
{
    public class FormMessageViewModel
    {
        [Required(ErrorMessage = "First Name is required!")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required!")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
    }
}
