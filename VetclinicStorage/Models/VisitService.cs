using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetclinicStorage.Models
{
    public class VisitService
    {
        public int VisitId { get; set; }
        public int ServiceId { get; set; }

        public virtual Visit Visit { get; set; }
        public virtual Service Service { get; set; }
    }
}
