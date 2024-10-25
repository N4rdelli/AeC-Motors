using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Yard
    {
        [Key]
        public Guid YardId { get; set; }

        [Display(Name = "Yard Name")]
        [Required(ErrorMessage = "The yard name is required")]
        public string YardName { get; set; }

        [Display(Name = "Yard Address")]
        [Required(ErrorMessage = "The yard address is required")]
        public string YardAddress { get; set; }

        [Display(Name = "Total Capacity")]
        [Required(ErrorMessage = "The total capacity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The total capacity must be a positive number")]
        public int YardTotalCapacity { get; set; }

        [Display(Name = "Current Quantity")]
        [Required(ErrorMessage = "The current quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The current quantity must be a non-negative number")]
        public int YardCurrentQuantity { get; set; }

        [Display(Name = "Current Color")]
        [Required(ErrorMessage = "The current color is required")]
        [MaxLength(50, ErrorMessage = "The current color cannot exceed 50 characters")]
        public string YardCurrentColor { get; set; }
    }
}
