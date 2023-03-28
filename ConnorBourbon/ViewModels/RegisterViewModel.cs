using System.ComponentModel.DataAnnotations;

namespace ConnorBourbon.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [UserName]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confrim Password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
  }
}