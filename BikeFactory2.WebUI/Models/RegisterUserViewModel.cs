using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BikeFactory2.WebUI.Models;

public class RegisterUserViewModel
{
    [Required]
    [EmailAddress]
    [DisplayName("Email")]

    public string NewEmail { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Compare("PasswordConfirm")]

    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Password confirmation is required.")]
    [DataType(DataType.Password)]
    [DisplayName("Repeat your password")]

    public string PasswordConfirm { get; set; } = string.Empty;
}
