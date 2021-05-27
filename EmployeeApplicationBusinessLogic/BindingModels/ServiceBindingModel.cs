using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BindingModels
{
    public class ServiceBindingModel : BindingModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }

        public virtual Dictionary<int, (string name, string description)> Medicines { get; set; }
    }
}
