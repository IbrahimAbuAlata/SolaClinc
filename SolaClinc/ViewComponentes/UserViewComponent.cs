using Microsoft.AspNetCore.Mvc;
using SolaClinc.Data;

namespace SolaClinc.ViewComponentes
{
	public class UserViewComponent : ViewComponent
	{
        private AppDbContext _context;
        public UserViewComponent(AppDbContext context)

        {
            _context = context;        
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.users.OrderByDescending(x=>x.Date));
        }
    }
}
