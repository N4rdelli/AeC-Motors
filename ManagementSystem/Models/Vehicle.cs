using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Vehicle
    {
        [Key]
        public Guid VehicleId { get; set; }   

        [Required]
        public string VehicleModel { get; set; }

        [Required]
        public string VehicleLicensePlate { get; set; }

        [Required]
        public string VehicleColor { get; set; }

        [Required]
        public string VehicleBrand { get; set; }
        
        [Required]
        public Guid YardId { get; set; }
        public Yard ? Yard {  get; set; }

        [Required]
        public string YardName { get; set;  
    }
}
