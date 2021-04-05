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
            this.Recommendation = new HashSet<Recommendation>();
            this.ServiceMedicine = new HashSet<ServiceMedicine>();
            this.VisitService = new HashSet<VisitService>();
        }
        [Key]
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        [ForeignKey("ServiceId")]
        public virtual ICollection<Recommendation> Recommendation { get; set; }
        [ForeignKey("ServiceId")]
        public virtual ICollection<ServiceMedicine> ServiceMedicine { get; set; }
        [ForeignKey("ServiceId")]
        public virtual ICollection<VisitService> VisitService { get; set; }
    }
}
