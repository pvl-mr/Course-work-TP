using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    public class Medicine
    {
        public Medicine()
        {
            this.MedicinesDinamics = new HashSet<MedicinesDinamic>();
            this.ServiceMedicines = new HashSet<ServiceMedicine>();
        }
        [Key]
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }

        [ForeignKey("MedicineId")]
        public virtual ICollection<MedicinesDinamic> MedicinesDinamics { get; set; }
        [ForeignKey("MedicineId")]
        public virtual ICollection<ServiceMedicine> ServiceMedicines { get; set; }
    }
}
