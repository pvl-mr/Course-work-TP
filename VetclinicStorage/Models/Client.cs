using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    public class Client
    {
        public Client()
        {
            this.Animals = new HashSet<Animal>();
            this.Visits = new HashSet<Visit>();
            this.Vaccinations = new HashSet<Vaccination>();
        }
        [Key]
        public int Id { get; set; }

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string NickName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Pass { get; set; }

        [ForeignKey("ClientId")]
        public virtual ICollection<Animal> Animals { get; set; }
        [ForeignKey("ClientId")]
        public virtual ICollection<Visit> Visits { get; set; }
        [ForeignKey("ClientId")]
        public virtual ICollection<Vaccination> Vaccinations { get; set; }
    }
}
