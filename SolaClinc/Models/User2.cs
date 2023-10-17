using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolaClinc.Models
{
	public class User2
	{
		public int User2Id { get; set; }
		[Required]
		public string? User2Name { get; set;}
		[Required]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
		[Required]
		[EmailAddress]
		public string? User2Email { get; set; }
		[Required]
		public string? User2Phone { get; set; }
		[ForeignKey("Role")]
		public int RoleId { get; set; }	
		public Role? Role { get; set; }	
	}
}
