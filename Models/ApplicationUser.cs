using Microsoft.AspNetCore.Identity;

namespace Online_Ticket_App.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
