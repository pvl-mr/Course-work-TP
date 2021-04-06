using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    class Animal
    {
        public Animal()
        {
            this.Vaccinations = new HashSet<Vaccination>();
            this.MedicinesDinamics = new HashSet<MedicinesDinamic>();
            this.VisitAnimals = new HashSet<VisitAnimal>();
        }
        [Key]
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Type { get; set; }
        [Required] public string Breed { get; set; }
        public string Description { get; set; }
        [Required] public int ClientId { get; set; }

        [ForeignKey("AnimalId")]
        public virtual ICollection<Vaccination> Vaccinations { get; set; }
        [ForeignKey("AnimalId")]
        public virtual ICollection<MedicinesDinamic> MedicinesDinamics { get; set; }
        public virtual Client Client { get; set; }
        [ForeignKey("AnimalId")]
        public virtual ICollection<VisitAnimal> VisitAnimals { get; set; }
    }
}
