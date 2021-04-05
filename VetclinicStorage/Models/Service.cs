using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    class Service
    {
        public Service()
        {
            this.Recommendations = new HashSet<Recommendation>();
            this.ServiceMedicines = new HashSet<ServiceMedicine>();
            this.VisitServices = new HashSet<VisitService>();
        }
        [Key]
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        [ForeignKey("ServiceId")]
        public virtual ICollection<Recommendation> Recommendations { get; set; }
        [ForeignKey("ServiceId")]
        public virtual ICollection<ServiceMedicine> ServiceMedicines { get; set; }
        [ForeignKey("ServiceId")]
        public virtual ICollection<VisitService> VisitServices { get; set; }
    }
}
