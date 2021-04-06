using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    class Visit
    {
        public Visit()
        {
            this.VisitAnimals = new HashSet<VisitAnimal>();
            this.VisitServices = new HashSet<VisitService>();
        }

        [Key]
        public int Id { get; set; }
        [Required] public DateTime Date { get; set; }
        public string Comment { get; set; }
        [Required] public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        [ForeignKey("VisitId")]
        public virtual ICollection<VisitAnimal> VisitAnimals { get; set; }
        [ForeignKey("VisitId")]
        public virtual ICollection<VisitService> VisitServices { get; set; }
    }
}
