using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; } 
        public List<int> ServicesId { get; set; }
        public int DoctorId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public int MedicineId { get; set; }
        public int ServiceId { get; set; }
    }
}
