using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetclinicStorage.Models
{
    class Vaccination
    {
        [Key]
        public int Id { get; set; }
        [Required] public System.DateTime Date { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        [Required] public int ClientId { get; set; }
        [Required] public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Client Client { get; set; }
    }
}
