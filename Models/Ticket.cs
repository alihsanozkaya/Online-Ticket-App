using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_App.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        //Unique Key
        public string TicketNo { get; set; }
        public int? ConcertId { get; set; }
        public int? SportId { get; set; }
        public int? TheaterId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
