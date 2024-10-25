using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Costumer
    {
        [Key]
        public Guid CostumerId { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Please enter the customer's name")]
        [MaxLength(255, ErrorMessage = "The customer name cannot exceed 255 characters")]
        public string CostumerName { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Please enter the customer's CPF")]
        [MaxLength(11, ErrorMessage = "The CPF must be 11 digits")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Please enter a valid CPF number")]
        public string CostumerCPF { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "Please enter the customer's RG")]
        [MaxLength(12, ErrorMessage = "The RG cannot exceed 12 characters")]
        public string CostumerRG { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter the customer's phone number")]
        [MaxLength(20, ErrorMessage = "The phone number cannot exceed 20 characters")]
        public string CostumerPhone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter the customer's email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string CostumerEmail { get; set; }

    }
}
