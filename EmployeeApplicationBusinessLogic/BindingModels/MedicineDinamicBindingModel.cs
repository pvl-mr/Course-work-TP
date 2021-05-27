using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BindingModels
{
    public class MedicineDinamicBindingModel : BindingModel
    {
        public System.DateTime Date { get; set; }
        public int Count { get; set; }
        public int DoctorId { get; set; }
        public int AnimalId { get; set; }

        public int MedicineId { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
