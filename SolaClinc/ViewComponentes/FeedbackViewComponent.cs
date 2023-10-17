using Microsoft.AspNetCore.Mvc;
using SolaClinc.Data;

namespace SolaClinc.ViewComponentes
{
	public class FeedbackViewComponent : ViewComponent
	{
		private AppDbContext _context;
        public FeedbackViewComponent(AppDbContext context)
        {
            _context = context;   
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.feedbacks.OrderByDescending(x=>x.Id));
        }
    }
}
