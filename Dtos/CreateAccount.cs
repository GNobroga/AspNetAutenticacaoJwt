using System.ComponentModel.DataAnnotations;

namespace Atividade_para_emprego.Dtos
{
    public class CreateAccount 
    {
        [Required(ErrorMessage = "The {0} field is required")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "The {0} needs a validate E-mail")]
        public string Email  { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The {0} is not equals 'Password'")]
        public string ConfirmationPassword { get; set; }
    }
}