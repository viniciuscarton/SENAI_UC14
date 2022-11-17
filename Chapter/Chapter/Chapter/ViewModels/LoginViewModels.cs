using System.ComponentModel.DataAnnotations;
namespace Chapter.ViewModels
{
    public class LoginViewModels
    {
        [Required (ErrorMessage = "E-mail requerido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha requerida")]
        public string? Senha { get; set; }
    }
}
