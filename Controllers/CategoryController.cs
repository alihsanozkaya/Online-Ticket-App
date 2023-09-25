using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Ticket_App.Models;
using Online_Ticket_App.Models.IRepository;
using Online_Ticket_App.Models.Repository;
using Online_Ticket_App.Utility;
using System.Data;

namespace Online_Ticket_App.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> categories = _categoryRepository.GetAll().ToList();
            return View(categories);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                TempData["basarili"] = "Kategori ekleme işlemi başarılı.";
                _categoryRepository.Save();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepository.Get(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.Delete(category);
            _categoryRepository.Save();
            TempData["basarili"] = "Kategori silme işlemi başarılı.";
            return RedirectToAction("Index", "Category");
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryDB = _categoryRepository.Get(u => u.Id == id);

            if (categoryDB == null)
            {
                return NotFound();
            }
            return View(categoryDB);
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                TempData["basarili"] = "Maç güncelleme işlemi başarılı.";
                _categoryRepository.Save();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
