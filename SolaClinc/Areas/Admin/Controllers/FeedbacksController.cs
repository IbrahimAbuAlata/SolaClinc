using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SolaClinc.Data;
using SolaClinc.Models;
using SolaClinc.Models.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace SolaClinc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedbacksController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _hostEnvironment;

        public FeedbacksController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Feedbacks
        public async Task<IActionResult> Index()
        {
            return _context.feedbacks != null ?
                        View(await _context.feedbacks.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.feedbacks'  is null.");
        }

        // GET: Admin/Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Admin/Feedbacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeedbackViewModel model)
        {
                if (ModelState.IsValid)
                {
                    string imgName = FileUpload(model);
                    Feedback feedback = new Feedback
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Email = model.Email,
                        Service = model.Service,
                        Description = model.Description,
                        Fedimg = imgName


                    };




                    _context.feedbacks.Add(feedback);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }

            // GET: Admin/Feedbacks/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null || _context.feedbacks == null)
                {
                    return NotFound();
                }

                var feedback = await _context.feedbacks.FindAsync(id);
                if (feedback == null)
                {
                    return NotFound();
                }
                return View(feedback);
            }

            // POST: Admin/Feedbacks/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Service,Description")] Feedback feedback)
            {
                if (id != feedback.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(feedback);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FeedbackExists(feedback.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(feedback);
            }

            // GET: Admin/Feedbacks/Delete/5

            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null || _context.feedbacks == null)
                {
                    return NotFound();
                }

                var feedback = await _context.feedbacks
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (feedback == null)
                {
                    return NotFound();
                }

                return View(feedback);
            }

            // POST: Admin/Feedbacks/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                if (_context.feedbacks == null)
                {
                    return Problem("Entity set 'AppDbContext.feedbacks'  is null.");
                }
                var feedback = await _context.feedbacks.FindAsync(id);
                if (feedback != null)
                {
                    _context.feedbacks.Remove(feedback);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool FeedbackExists(int id)
            {
                return (_context.feedbacks?.Any(e => e.Id == id)).GetValueOrDefault();
            }

            public string FileUpload(FeedbackViewModel model)
            {
                string wwwPath = _hostEnvironment.WebRootPath;
                if (string.IsNullOrEmpty(wwwPath)) { }
                string contentPath = _hostEnvironment.ContentRootPath;
                if (string.IsNullOrEmpty(contentPath)) { }
                string p = Path.Combine(wwwPath, "Uploads");
                if (!Directory.Exists(p))
                {
                    Directory.CreateDirectory(p);
                }
                string fileName = Path.GetFileNameWithoutExtension(model.Fedimg!.FileName);
                string newImgName = "SOLA" + fileName + "_" + Guid.NewGuid().ToString() + Path.GetExtension(model.Fedimg!.FileName);
                using (FileStream fileStream = new FileStream(Path.Combine(p, newImgName), FileMode.Create))
                {
                    model.Fedimg.CopyTo(fileStream);
                }

                return "\\Uploads\\" + newImgName;
            }

        }

    }


