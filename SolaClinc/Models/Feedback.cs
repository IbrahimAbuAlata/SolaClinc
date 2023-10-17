using System.ComponentModel.DataAnnotations;

namespace SolaClinc.Models
{
	public class Feedback
	{
		public int Id { get; set; }
		[Required]
        public string? Name { get; set; }
		[EmailAddress]
		public string? Email { get; set; }
		public string? Service { get; set; }
		public string? Description { get; set; }	
		public string? Fedimg { get; set; }	


	}
}
