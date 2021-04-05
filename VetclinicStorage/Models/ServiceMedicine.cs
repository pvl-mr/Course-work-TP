using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetclinicStorage.Models
{
    class ServiceMedicine
    {
        public int ServiceId { get; set; }
        public int MedicineId { get; set; }

        public virtual Service Service { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
