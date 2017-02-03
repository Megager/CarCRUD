using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectAuto.Models
{
    public enum CarType
    {
        Passenger,
        Truck
    }
    public class Car
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage="Enter the car model")]
        public string CarModel { get; set; }
        [Required(ErrorMessage="Enter the car mark")]
        public string CarMark { get; set; }
        public CarType CarType { get; set; }
        public int Price { get; set; }
        [Required]
        [Range(1900,2100,ErrorMessage = "Year must be between 1900 and 2100")]
        public int Year { get; set; }

        public virtual ICollection<Owner> Owners { get; set; }
    }
}