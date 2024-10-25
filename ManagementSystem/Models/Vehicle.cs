using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Vehicle
    {
        [Key]
        public Guid VehicleId { get; set; }

        [Display(Name = "Vehicle Model")]
        [Required(ErrorMessage = "Please include the vehicle's color make, model, and year")]
        [MaxLength(255, ErrorMessage = "The vehicle model cannot exceed 255 characters")]
        public string VehicleModel { get; set; }

        [Display(Name = "License Plate")]
        [Required(ErrorMessage = "Please enter the vehicle's license plate")]
        [MaxLength(20, ErrorMessage = "The license plate cannot exceed 20 characters")]
        public string VehicleLicensePlate { get; set; }

        [Display(Name = "Yard")]
        [Required(ErrorMessage = "Please select a yard for the vehicle")]
        public Guid YardId { get; set; }

        public Yard? Yard { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please specify the vehicle's status")]
        public bool VehicleStatus { get; set; }

        [Display(Name = "Rental Price")]
        [Required(ErrorMessage = "Please enter the vehicle's rental price")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "The rental price must be a non-negative number")]
        public decimal VehicleRentalPrice { get; set; }
        public class Carro
        {
            public int Id { get; set; }
            public string Modelo { get; set; }
            public string Marca { get; set; }
            public decimal PrecoDiaria { get; set; }
            // ... outros atributos
        }

        public class AluguelViewModel
        {
            public int CarroId { get; set; }
            public DateTime DataInicio { get; set; }
            public DateTime DataFim { get; set; }
            public decimal Desconto { get; set; }
            public decimal PrecoTotal { get; set; }
        }

    }
    }

   
    

