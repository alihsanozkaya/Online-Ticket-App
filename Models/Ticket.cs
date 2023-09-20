using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Ticket_App.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        //Unique Key
        public string TicketNo { get; set; }
        [ValidateNever]
        public int? ConcertId { get; set; }
        [ForeignKey("ConcertId")]
        [ValidateNever]
        public Concert? Concert { get; set; }
        [ValidateNever]
        public int? SportId { get; set; }
        [ForeignKey("SportId")]
        [ValidateNever]
        public Sport? Sport { get; set; }
        [ValidateNever]
        public int? TheaterId { get; set; }
        [ForeignKey("TheaterId")]
        [ValidateNever]
        public Theater? Theater { get; set; }
        [ValidateNever]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public IdentityUser? IdentityUser { get; set; }
        [ValidateNever]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category? Category { get; set; }
        public int PersonCount { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
