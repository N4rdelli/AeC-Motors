using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Rental
    {
        [Key]
        public Guid RentalId { get; set; }
    }
}
