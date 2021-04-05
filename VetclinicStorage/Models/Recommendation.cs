using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    class Recommendation
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int DoctorId { get; set; }
        [Required] public int ServiceId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Service Service { get; set; }
    }
}
