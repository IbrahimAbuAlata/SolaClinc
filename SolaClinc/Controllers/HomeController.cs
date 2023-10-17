using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolaClinc.Data;
using SolaClinc.Models;
using SolaClinc.Models.ViewModels;
using System.Diagnostics;

namespace SolaClinc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext _db;
        public HomeController(ILogger<HomeController> logger , AppDbContext db )
        {
            _db = db;
            _logger = logger;
           
        }

        public IActionResult Index()
        {
            ServiceFeedBacksViewModel model = new ServiceFeedBacksViewModel()

			 
			 {
                Services = _db.services.ToList(),
				Feedbacks = _db.feedbacks.ToList(),
               
                
            };
        

            return View(model);
        }
		public async Task<IActionResult> ServiceDetiles(int? id)
		{
			if (id == null || _db.services == null)
			{
				return NotFound();
			}

			var ser = await _db.services
				.FirstOrDefaultAsync(m => m.ServiceId == id);
			if (ser == null)
			{
				return NotFound();
			}

			return View(ser);
		}

		public IActionResult SuccsessAppointment()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}