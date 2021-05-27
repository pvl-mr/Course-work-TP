using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BindingModels
{
   public  class VaccinationBindingModel : BindingModel
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }

        public int AnimalId { get; set; }
    }
}
