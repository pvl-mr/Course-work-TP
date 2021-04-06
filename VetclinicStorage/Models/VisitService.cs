using System;
using System.Collections.Generic;
using System.Text;

namespace VetclinicStorage.Models
{
    class VisitService
    {
        public int VisitId { get; set; }
        public int ServiceId { get; set; }
        public virtual Visit Visit { get; set; }
        public virtual Service Service { get; set; }
    }
}
