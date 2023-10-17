using System.ComponentModel.DataAnnotations;

namespace SolaClinc.Models.ViewModels
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Service { get; set; }
        public string? Description { get; set; }
        public IFormFile? Fedimg { get; set; }
    }
}
