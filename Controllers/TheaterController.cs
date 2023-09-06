using Microsoft.AspNetCore.Mvc;
using Online_Ticket_App.Models;
using Online_Ticket_App.Models.IRepository;

namespace Online_Ticket_App.Controllers
{
    public class TheaterController : Controller
    {
        private readonly ITheaterRepository _theaterRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TheaterController(ITheaterRepository theaterRepository, IWebHostEnvironment webHostEnvironment)
        {
            _theaterRepository = theaterRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Theater> theaterList = _theaterRepository.GetAll().ToList();
            return View(theaterList);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Theater theater, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string theaterPath = Path.Combine(wwwRootPath, @"img\theater");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(theaterPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    theater.PhotoUrl = @"\img\theater\" + file.FileName;
                }
                _theaterRepository.Add(theater);
                TempData["basarili"] = "Tiyatro ekleme işlemi başarılı.";
                _theaterRepository.Save();
                return RedirectToAction("Index", "Theater");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Theater? theater = _theaterRepository.Get(u => u.Id == id);

            if (theater == null)
            {
                return NotFound();
            }
            return View(theater);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Theater? theater = _theaterRepository.Get(u => u.Id == id);

            if (theater == null)
            {
                return NotFound();
            }
            _theaterRepository.Delete(theater);
            _theaterRepository.Save();
            TempData["basarili"] = "Tiyatro silme işlemi başarılı.";
            return RedirectToAction("Index", "Theater");
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Theater theaterDB = _theaterRepository.Get(u => u.Id == id);

            if (theaterDB == null)
            {
                return NotFound();
            }
            return View(theaterDB);
        }
        [HttpPost]
        public IActionResult Update(Theater theater, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string theaterPath = Path.Combine(wwwRootPath, @"img\theater");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(theaterPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    theater.PhotoUrl = @"\img\theater\" + file.FileName;
                }
                _theaterRepository.Update(theater);
                TempData["basarili"] = "Tiyatro güncelleme işlemi başarılı.";
                _theaterRepository.Save();
                return RedirectToAction("Index", "Theater");
            }
            return View();
        }
    }
}
