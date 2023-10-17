using System.ComponentModel.DataAnnotations;

namespace SolaClinc.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? User2Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
