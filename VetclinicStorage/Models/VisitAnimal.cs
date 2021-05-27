using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetclinicStorage.Models
{
    public class VisitAnimal
    {
        public int VisitId { get; set; }
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
