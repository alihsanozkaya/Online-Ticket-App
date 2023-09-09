using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Ticket_App.Models;
using Online_Ticket_App.Models.IRepository;
using Online_Ticket_App.Utility;
using System.Composition;
using System.Data;

namespace Online_Ticket_App.Controllers
{
    public class SportController : Controller
    {
        private readonly ISportRepository _sportRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SportController(ISportRepository sportRepository, IWebHostEnvironment webHostEnvironment)
        {
            _sportRepository = sportRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Sport> sportList = _sportRepository.GetAll().ToList();
            return View(sportList);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Add(Sport sport, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string sportPath = Path.Combine(wwwRootPath, @"img\sport");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(sportPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    sport.PhotoUrl = @"\img\sport\" + file.FileName;
                }
                _sportRepository.Add(sport);
                TempData["basarili"] = "Maç ekleme işlemi başarılı.";
                _sportRepository.Save();
                return RedirectToAction("Index", "Sport");
            }
            return View();
        }
        public IActionResult Buy(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            if (User.Identity.IsAuthenticated)
            {
                Sport? sport = _sportRepository.Get(u => u.Id == id);
                if (sport == null)
                {
                    return NotFound();
                }
                return View(sport);
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }

        }
        [HttpPost]
        public IActionResult Buy(Sport sport)
        {
            return View(sport);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Sport? sport = _sportRepository.Get(u => u.Id == id);
            if (sport == null)
            {
                return NotFound();
            }
            return View(sport);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Sport? sport = _sportRepository.Get(u => u.Id == id);

            if (sport == null)
            {
                return NotFound();
            }
            _sportRepository.Delete(sport);
            _sportRepository.Save();
            TempData["basarili"] = "Maç silme işlemi başarılı.";
            return RedirectToAction("Index", "Sport");
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Sport sportDB = _sportRepository.Get(u => u.Id == id);

            if (sportDB == null)
            {
                return NotFound();
            }
            return View(sportDB);
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Update(Sport sport, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string sportPath = Path.Combine(wwwRootPath, @"img\sport");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(sportPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    sport.PhotoUrl = @"\img\sport\" + file.FileName;
                }
                _sportRepository.Update(sport);
                TempData["basarili"] = "Maç güncelleme işlemi başarılı.";
                _sportRepository.Save();
                return RedirectToAction("Index", "Sport");
            }
            return View();
        }
    }

}
