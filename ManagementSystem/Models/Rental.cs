using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Rental
    {
        [Key]
        public Guid RentalId { get; set; }

        [Required]
        public Guid CostumerId { get; set; }
        public Costumer ? Costumer { get; set; }

        [Required]
        public Guid VehicleId { get; set; }
        public Vehicle ? Vehicle { get; set; }

        [Required]
        public DateTime RentalStart { get; set; }

        [Required]
        public DateTime RentalEnd { get; set; }

        [Required]
        public decimal RentalPrince { get; set; } = 0;
    }
}
