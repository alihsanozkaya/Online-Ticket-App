using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Ticket_App.Models;
using Online_Ticket_App.Models.IRepository;
using Online_Ticket_App.Models.Repository;
using Online_Ticket_App.Utility;
using System;
using System.Data;

namespace Online_Ticket_App.Controllers
{
    public class ConcertController : Controller
    {
        private readonly IConcertRepository _concertRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ConcertController(IConcertRepository concertRepository, IWebHostEnvironment webHostEnvironment)
        {
            _concertRepository = concertRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Concert> concertList = _concertRepository.GetAll().ToList();
            return View(concertList);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Add(Concert concert, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string concertPath = Path.Combine(wwwRootPath, @"img\concert");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(concertPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    concert.PhotoUrl = @"\img\concert\" + file.FileName;
                }
                _concertRepository.Add(concert);
                TempData["basarili"] = "Konser ekleme işlemi başarılı.";
                _concertRepository.Save();
                return RedirectToAction("Index", "Concert");
            }
            return View();
        }
        public IActionResult Buy(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Concert? concert = _concertRepository.Get(u => u.Id == id);
                if (concert == null)
                {
                    return NotFound();
                }
                return View(concert);
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }
        [HttpPost]
        public IActionResult Buy(Concert concert)
        {
            return View(concert);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Concert? concert = _concertRepository.Get(u => u.Id == id);

            if (concert == null)
            {
                return NotFound();
            }
            return View(concert);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Concert? concert = _concertRepository.Get(u => u.Id == id);

            if (concert == null)
            {
                return NotFound();
            }
            _concertRepository.Delete(concert);
            _concertRepository.Save();
            TempData["basarili"] = "Konser silme işlemi başarılı.";
            return RedirectToAction("Index", "Concert");
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Concert? concertDB = _concertRepository.Get(u => u.Id == id);

            if (concertDB == null)
            {
                return NotFound();
            }
            return View(concertDB);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Update(Concert concert, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string concertPath = Path.Combine(wwwRootPath, @"img\concert");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(concertPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    concert.PhotoUrl = @"\img\concert\" + file.FileName;
                }
                _concertRepository.Update(concert);
                TempData["basarili"] = "Konser güncelleme işlemi başarılı.";
                _concertRepository.Save();
                return RedirectToAction("Index", "Concert");
            }
            return View();
        }
    }

}
