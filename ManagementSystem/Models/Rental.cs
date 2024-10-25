using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Rental
    {
        [Key]
        public Guid RentalId { get; set; }

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "Please select a customer for the rental")]
        public Guid CostumerId { get; set; }
        public Costumer? Costumer { get; set; }

        [Display(Name = "Vehicle")]
        [Required(ErrorMessage = "Please select a vehicle for the rental")]
        public Guid VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        [Display(Name = "Rental Start Date")]
        [Required(ErrorMessage = "Please enter the rental start date")]
        public DateOnly RentalStart { get; set; }

        [Display(Name = "Rental End Date")]
        [Required(ErrorMessage = "Please enter the rental end date")]
        public DateOnly RentalEnd { get; set; }

        [Display(Name = "Rental Price")]
        public decimal RentalPrince { get; private set; } = 0;

        [Display(Name = "Rental Discount")]
        [Required(ErrorMessage = "Please enter the rental discount")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "The rental discount must be a non-negative number")]
        public decimal RentalDiscount { get; set; } = 0;

        [Display(Name = "Rental Status")]
        [Required(ErrorMessage = "Please specify whether the rental is scheduled, in progress, or completed")]
        [MaxLength(50, ErrorMessage = "The rental status cannot exceed 50 characters")]
        public string RentalStatus { get; set; }

        [Display(Name = "Payment Status")]
        public bool RentalPaymentStatus { get; set; }


        }
    }

