using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BindingModels
{
    public class RecommendationBindingModel : BindingModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }

    }
}
