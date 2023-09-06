using Microsoft.AspNetCore.Mvc;

namespace Online_Ticket_App.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Operation()
        {
            return View();
        }
    }
}
