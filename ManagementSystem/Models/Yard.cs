using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Yard
    {
        [Key]
        public Guid YardId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nomw é obrigatório")]
        public string YardName { get; set; }

        [Required]
        public string YardAddress { get; set; }

        [Required]
        public int YardTotalCapacity { get; set; }

        [Required]
        public int YardCurrentQuantity { get; set; }

        [Required]
        public string YardCurrentColor { get; set; }
    }
}
