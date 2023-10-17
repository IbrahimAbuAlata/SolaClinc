namespace SolaClinc.Models.ViewModels
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public IFormFile? ServiceImg { get; set; }
        public string? ServiceDescription { get; set; }
    }
}
