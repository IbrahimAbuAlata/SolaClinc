using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolaClinc.Data;
using SolaClinc.Models;
using SolaClinc.Models.ViewModels;

namespace SolaClinc.Controllers
{
	public class AccountController : Controller
	{
		private AppDbContext _db;
        public AccountController(AppDbContext db)
        {
			_db = db;	

        }
   
		public IActionResult CreateRole()
		{

			return View();
		}
		[HttpPost]
        public IActionResult CreateRole(Role role)
        {
			if (role==null) { return NotFound(); }
			if (ModelState.IsValid)
			{
				_db.roles.Add(role);
                _db.SaveChanges();
				return RedirectToAction("RolesList");
            }
			
            return View(role);
        }
		public IActionResult RolesList()
		{
			return View(_db.roles);
		}
        public IActionResult Register()
        {
			ViewBag.Roles = new SelectList(_db.roles, "RoleId", "RoleName");

            return View();
        }

		[HttpPost]
        public IActionResult Register(User2 user2)
		{
			if(ModelState.IsValid)
			{
				_db.users2.Add(user2);
				_db.SaveChanges();
				return RedirectToAction("Login");
			}
			return View(user2);

		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
			if (ModelState.IsValid)
			{
				var data = _db.users2.Where(x => x.User2Name == model.User2Name && x.Password == model.Password);
					if (data.Any())
				{
					return RedirectToAction( "Index" ,"Dashboard" , new { area = "Admin" } );
				}
				ModelState.AddModelError("", "Invalid User Or Password");
                return View(model);
            }
            return View(model);
        }
    }
}
