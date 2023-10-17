using System.ComponentModel.DataAnnotations.Schema;

namespace SolaClinc.Models
{
	public class Service
	{
		public int ServiceId { get; set; }
		public string? ServiceName { get; set; }
		public string? ServiceImg { get; set; }
		public string? ServiceDescription { get; set;}
	}
}
