using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    class MedicinesDinamic
    {
        [Key]
        public int Id { get; set; }
        [Required] public System.DateTime Date { get; set; }
        [Required] public int Count { get; set; }
        [Required] public int DoctorId { get; set; }
        [Required] public int AnimalId { get; set; }
        [Required] public int MedicineId { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
