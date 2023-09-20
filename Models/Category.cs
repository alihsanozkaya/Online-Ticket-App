using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_App.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
