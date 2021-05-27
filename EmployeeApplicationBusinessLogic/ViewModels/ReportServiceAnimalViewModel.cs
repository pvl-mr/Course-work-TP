using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.ViewModels
{
    public class ReportServiceAnimalViewModel
    {
        public string ServiceName { get; set; }
        public DateTime Date { get; set; }

        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public string AnimalBreed { get; set; }

        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientNickName { get; set; }
    }
}
