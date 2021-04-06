using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Services = new HashSet<Service>();
            this.Recommendations = new HashSet<Recommendation>();
            this.MedicinesDinamics = new HashSet<MedicinesDinamic>();
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
        public virtual ICollection<Service> Services { get; set; }
        [ForeignKey("DoctorId")]
        public virtual ICollection<Recommendation> Recommendations { get; set; }
        [ForeignKey("DoctorId")]
        public virtual ICollection<MedicinesDinamic> MedicinesDinamics { get; set; }
    }
}
