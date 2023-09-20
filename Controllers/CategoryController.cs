using Microsoft.AspNetCore.Mvc;
using Online_Ticket_App.Models;
using Online_Ticket_App.Models.IRepository;

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
    }
}
