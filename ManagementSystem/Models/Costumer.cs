using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Costumer
    {
        [Key]
        public Guid CostumerId { get; set; }

        [Required]
        public string CostumerName { get; set; }

        [Required]
        public string CostumerCPF { get; set; }

        [Required]
        public string CostumerRG { get; set; }

        [Required]
        public string CostumerPhone { get; set; }

        [Required]
        public string CostumerEmail { get; set; }

    }
}
