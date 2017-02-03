using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectAuto.Models
{
    public class Owner
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter the owner first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter the owner second name")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Please enter your birth year")]
        [Range(1900, 2017, ErrorMessage = "Year of birth must be between 1900 and 2017")]
        public int YearOfBirth { get; set; }
        [Required]
        [Range(0, 70, ErrorMessage = "Driver expirience must be between 0 and 70")]
        
        public int DriverExpirience { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}