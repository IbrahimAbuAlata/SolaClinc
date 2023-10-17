using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace SolaClinc.Models
{
	public class User
	{
		public int UserId { get; set; }
		[Required]
		public string? UserName { get; set; }
		[Required]
		[EmailAddress]
		public string? UserEmail { get; set;}
		[Required]
		public string? UserPhone { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime Date { get; set; }

	}
}
