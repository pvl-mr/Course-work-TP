using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    class Doctor
    {
        public Doctor()
        {
            this.Service = new HashSet<Service>();
            this.Recommendation = new HashSet<Recommendation>();
            this.MedicinesDinamic = new HashSet<MedicinesDinamic>();
        }
        [Key]
        public int Id { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string NickName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Pass { get; set; }
        [Required] public string Post { get; set; }

        [ForeignKey("DoctorId")]
        public virtual ICollection<Service> Service { get; set; }
        [ForeignKey("DoctorId")]
        public virtual ICollection<Recommendation> Recommendation { get; set; }
        [ForeignKey("DoctorId")]
        public virtual ICollection<MedicinesDinamic> MedicinesDinamic { get; set; }
    }
}
