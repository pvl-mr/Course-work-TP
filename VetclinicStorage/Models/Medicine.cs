using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    class Medicine
    {
        public Medicine()
        {
            this.MedicinesDinamic = new HashSet<MedicinesDinamic>();
            this.ServiceMedicine = new HashSet<ServiceMedicine>();
        }
        [Key]
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }

        [ForeignKey("MedicineId")]
        public virtual ICollection<MedicinesDinamic> MedicinesDinamic { get; set; }
        [ForeignKey("MedicineId")]
        public virtual ICollection<ServiceMedicine> ServiceMedicine { get; set; }
    }
}
