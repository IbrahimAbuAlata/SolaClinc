using Microsoft.AspNetCore.Mvc;
using SolaClinc.Data;

namespace SolaClinc.ViewComponentes
{
	public class ServiceViewComponent : ViewComponent
	{
		private AppDbContext _context;

        public ServiceViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.services.OrderByDescending(x=>x.ServiceId));
        }



    }
}
