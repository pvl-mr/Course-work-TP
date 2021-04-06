using System;
using System.Collections.Generic;
using System.Text;

namespace VetclinicStorage.Models
{
    class VisitAnimal
    {
        public int VisitId { get; set; }
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
